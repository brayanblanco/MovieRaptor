# MovieRaptor

A federated social network to discuss films.

---

## Prerequisites

**To just run the project:** Docker, plus the .NET SDK **once** to generate
the development certificate (`dotnet dev-certs https`). The Dockerfile
builds inside a `mcr.microsoft.com/dotnet/sdk:10.0` image, so no .NET
tooling is needed beyond that. If you disable HTTPS (see
[HTTPS](#https)), Docker alone is enough.

**To develop / contribute code:** Docker **and** the **.NET 10 SDK**.
This project targets `net10.0`; older SDKs fail with
`NETSDK1045: The current .NET SDK does not support targeting .NET 10.0`.

- **Docker** — [Docker Desktop](https://www.docker.com/products/docker-desktop/)
  on Windows/macOS; `docker` + the Compose plugin on Linux. Add your user
  to the `docker` group, or prefix commands with `sudo`.
- **.NET 10 SDK** — <https://dotnet.microsoft.com/download/dotnet/10.0>
  - Arch Linux: `sudo pacman -Ss dotnet-sdk` (if the offered version is
    older than 10, use `dotnet-install.sh --channel 10.0`)
- An IDE with Docker Compose support: **Rider**, **Visual Studio 2022**,
  or **VS Code** + C# Dev Kit.

Verify:

```bash
docker --version
docker compose version
dotnet --version   # 10.x — contributors only
```

> **Arch Linux:** also install `docker-buildx`
> (`sudo pacman -S docker-buildx`). Arch ships Buildx as a separate
> package, and builds fail without it with
> `BuildKit is enabled but the buildx component is missing`.

---

## Quick start

```bash
git clone https://github.com/brayanblanco/MovieRaptor.git
cd MovieRaptor
dotnet dev-certs https    # once per machine — HTTPS is on by default
docker compose up --build
```

Once the containers are up:

- **HTTPS:** <https://localhost:8081>
- **HTTP:** <http://localhost:8080>

The API applies EF Core migrations automatically on startup, so the schema
is created on first run.

> Don't want HTTPS? See [HTTPS](#https) for the two lines to comment out in
> `docker-compose.override.yml`. With HTTPS disabled, `dotnet dev-certs`
> isn't needed and Docker is the only prerequisite.

Stop with:

```bash
docker compose down
```

To also **delete the database volume** and start from a clean schema:

```bash
docker compose down -v
```

> The development database credentials (`root` / `secret`) are set in
> `docker-compose.yml` and are for local development only.

---

## Configuration

`docker-compose.override.yml` mounts two host directories into the
container: your .NET **user-secrets** directory and the **certificate
store**. Both default to their standard Linux/macOS locations, so
**no configuration is required** for a typical setup.

If your files live somewhere else, copy the template and edit it:

```bash
cp .env.example .env
```

`.env` is gitignored; `.env.example` is what gets shared. Verify the
paths resolved correctly before starting:

```bash
docker compose config | grep -A6 volumes
```

You should see real absolute paths (e.g. `/home/you/.microsoft/usersecrets`)
on the left of each mapping. An empty source (`:/home/app/...`) means the
variable didn't expand — check your `.env`.

### The Movie DB API key

The API calls [The Movie DB](https://www.themoviedb.org/). Create a free
key at <https://www.themoviedb.org/settings/api>, then set it in
`MovieRaptor.API/appsettings.Development.json`:

```json
{
  "TMDbApiKey": "your-key-here"
}
```

`appsettings.json` ships with a placeholder (`"TMDbApiKey": "1234"`). The
app boots without a real key, but TMDB-backed endpoints fail until one is
set.

Because `appsettings.Development.json` is copied into the image at build
time, changes to it need a rebuild:

```bash
docker compose up --build
```

Alternatively, use user secrets (see below), which are mounted rather than
baked in and take effect on a plain restart:

```bash
dotnet user-secrets set "TMDbApiKey" "your-key-here" --project MovieRaptor.API
```

**Don't commit a real key.** `appsettings.Development.json` is already in
the .gitignore file, so make sure you put your correct key in that file and
not in the general `appsettings.json`.


### HTTPS

HTTPS is **enabled by default** on `8081` and requires a development
certificate on the host. Generate it once per machine (needs the SDK):

```bash
dotnet dev-certs https
```

Add `--trust` if you want the browser to accept it without warnings
(requires `sudo` on Linux).

On Linux the certificate is written to
`~/.dotnet/corefx/cryptography/x509stores/my`, which
`docker-compose.override.yml` mounts into the container. Without a
certificate, Kestrel refuses to start and the container exits with
`Unable to configure HTTPS endpoint. No server certificate was specified`.

> Certificate discovery relies on the Linux x509 store. On Windows either
> disable HTTPS (below), or configure an explicit `.pfx` path under
> `%APPDATA%\ASP.NET\Https`.

**To run HTTP-only**, comment out these two lines in
`docker-compose.override.yml`:

```yaml
#      - ASPNETCORE_HTTPS_PORTS=8081
#      - "8081:8081"
```

Then `docker compose up --build` serves on <http://localhost:8080> with no
certificate required, and Docker becomes the only prerequisite.

### User secrets (optional)

The API has a `UserSecretsId` and, because the container runs with
`ASPNETCORE_ENVIRONMENT=Development`, user secrets are loaded from
`~/.microsoft/usersecrets/<id>/secrets.json` (mounted read-only).

They are **not required** — the app runs without them. To add your own:

```bash
dotnet user-secrets set "SomeKey" "value" --project MovieRaptor.API
dotnet user-secrets list --project MovieRaptor.API
```

On Linux the directory is all lowercase (`usersecrets`). Docker
auto-creates missing mount sources, so a wrong-case path fails silently
with an empty directory rather than an error.

---

## Running from an IDE

**Visual Studio (Windows):** Docker support is preconfigured; press F5.

**Rider / VS Code:** create a **Docker Compose** run configuration
pointing at `docker-compose.yml` **and** `docker-compose.override.yml`,
with `movieraptor.api` selected as the service.

> ⚠️ Do **not** use a "Dockerfile" run configuration. It starts only the
> API container, on its own isolated network, so the hostname `postgres`
> can't be resolved and the API crashes with
> `System.Net.Sockets.SocketException: Name or service not known`.
> Both containers must be launched through Compose to share a network.

IDE run configurations live in `.idea/` / `.vs/`, which are gitignored —
each collaborator creates their own once.

---

## Database migrations

Applied automatically at API startup via `Database.Migrate()`.

To **author** a new migration, use the `dotnet-ef` global tool from the
host (the runtime container has no SDK, so it can't run there):

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add <Name> \
  --project MovieRaptor.Infrastructure \
  --startup-project MovieRaptor.API
```

---

## Troubleshooting

| Symptom | Cause / fix |
|---|---|
| `BuildKit is enabled but the buildx component is missing` | Install `docker-buildx` (Arch: `sudo pacman -S docker-buildx`). |
| `Name or service not known` for `postgres` | The API is running outside Compose. Use a Docker Compose run configuration, not a Dockerfile one. |
| Invalid mount path / empty source in `volumes` | `.env` has unexpanded values, or `$HOME` didn't expand. Run `docker compose config` to see resolved paths. |
| `Unable to configure HTTPS endpoint` | No dev certificate. Run `dotnet dev-certs https`, or disable HTTPS in `docker-compose.override.yml` (see [HTTPS](#https)). *If* the mount is correct and it still fails, the store files may not be readable by the container user (UID 1654) — try `chmod -R a+r ~/.dotnet/corefx/cryptography/x509stores/my`. |
| App fails to start after editing compose files | A stale container may still hold the ports. Run `docker compose down --remove-orphans` before `docker compose up --build`. |
| `Connection refused` connecting to Postgres on first boot | Postgres is still running `initdb`. Add a `pg_isready` healthcheck to the `postgres` service and `depends_on: { postgres: { condition: service_healthy } }`. |
