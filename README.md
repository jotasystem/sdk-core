# JotaSystem.Sdk.Core

Biblioteca central da **Jota System** com contratos, estruturas base e componentes arquiteturais para aplicações .NET.

## Descrição

O `JotaSystem.Sdk.Core` organiza os elementos centrais usados na construção de APIs e serviços da empresa.

Hoje o pacote contém:

- `Domain` com entidades base, suporte a `AggregateRoot`, `soft delete`, multitenancy, `ValueObject` e `Domain Events`.
- `Application` com contratos de `command`, `query`, `use case`, validação, filtros dinâmicos, paginação e resultados padronizados.
- `Infrastructure` com contratos de repositório, `UnitOfWork`, transação, mapeamento e specifications.
- `CrossCutting` com exceções, contratos de segurança, contexto atual, claims, settings, modelos compartilhados e interfaces de providers.
- `API/Extensions` para autenticação, CORS, controllers, OpenAPI, Serilog, pipeline e localização.
- Utilitários adicionais, como geração de código de barras e QR Code.

## Contratos relevantes

Entre os contratos públicos mais importantes hoje estão:

- `ICurrentContext` e `IClaimsProvider` para identidade e contexto autenticado.
- `IAddressProvider`, `IAiProvider`, `IEmailProvider` e `IStorageProvider` para abstração de integrações externas.
- `JwtSetting`, `EmailSetting`, `PaymentSetting`, `SmsSetting`, `StorageSetting`, `AiSetting` e `SerilogSetting` para configuração de infraestrutura.

## Papel na arquitetura

Este SDK funciona como o núcleo arquitetural do conjunto. Ele define contratos e modelos que podem ser implementados por outros pacotes, como providers e aplicações consumidoras.
