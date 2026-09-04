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
- `IPaymentProvider` com o contrato de cobrança: `PaymentProviderRequest`/`PaymentProviderResult`, `PaymentCard`, `PaymentAddress` e `PaymentRecurrence`.
- `JwtSetting`, `EmailSetting`, `PaymentSetting`, `SmsSetting`, `StorageSetting`, `AiSetting` e `SerilogSetting` para configuração de infraestrutura.

### Dados de cartão

`PaymentCard` transporta os dados do cartão até o gateway, mas **não** os expõe para fora do processo: `Number` e `SecurityCode` são marcados com `JsonIgnore` e ficam de fora do `ToString` gerado pelo record. Assim, um payload de auditoria, um log de requisição ou um `RequestPayloadJson` persistido nunca carregam o PAN nem o CVV. Para rastreabilidade use `MaskedNumber`, que preserva apenas o BIN e os quatro últimos dígitos.

Quando o cartão já estiver tokenizado no gateway, informe apenas `Token` — é o caminho recomendado, porque mantém a aplicação fora do escopo PCI.

## Papel na arquitetura

Este SDK funciona como o núcleo arquitetural do conjunto. Ele define contratos e modelos que podem ser implementados por outros pacotes, como providers e aplicações consumidoras.
