[![](https://img.shields.io/nuget/v/soenneker.algolia.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.algolia.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.algolia.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.algolia.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.algolia.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.algolia.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.algolia.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.algolia.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Algolia.OpenApiClient

A Kiota-generated .NET client containing request builders and models for Algolia APIs.

## Installation

```bash
dotnet add package Soenneker.Algolia.OpenApiClient
```

## Creating the client

`AlgoliaOpenApiClient` requires a configured Kiota request adapter:

```csharp
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Algolia.OpenApiClient;

httpClient.BaseAddress = new Uri("https://status.algolia.com");

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new AlgoliaOpenApiClient(adapter);
```

For dependency-injection setup with Algolia authentication headers, use [`Soenneker.Algolia.OpenApiClientUtil`](https://www.nuget.org/packages/Soenneker.Algolia.OpenApiClientUtil).

## Usage

The top-level client groups operations by Algolia product:

```csharp
using Soenneker.Algolia.OpenApiClient.Models;

StatusResponseResponse? status = await client
    .Monitoring
    .One
    .Status
    .GetAsync(cancellationToken: cancellationToken);
```

Request and response types are in `Soenneker.Algolia.OpenApiClient.Models`. Generated operations expose Kiota request configuration for headers, query parameters, and middleware options where supported.

## Important behavior

- Algolia products use different hosts, and some hosts vary by application or region. One client has one adapter base URL, so configure an independently created client for each host you need to call.
- Do not rely on the generated placeholder base URL (`https://analytics.{region}.algolia.com`); replace it with a concrete host before sending requests.
- Most authenticated APIs require both `X-Algolia-Application-Id` and `X-Algolia-API-Key`. Public monitoring endpoints are an exception.
- Kiota throws `ApiException` for mapped non-success responses.
- The source is generated. Configure authentication, retries, and logging in the adapter or HTTP pipeline instead of editing generated files.
