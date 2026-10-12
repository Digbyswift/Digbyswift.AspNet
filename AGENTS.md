# AGENTS.md

## Purpose

This repository is a reference template for Digbyswift .NET NuGet packages.

The goal is to keep package structure, CI, versioning, tests, documentation, and release flow consistent across repositories.

## Repository layout

- `src/` → package source code
- `src/*.Tests/` → test projects

### Key files

- `README.md` → package overview and usage examples
- `src/Directory.Build.props` → shared build settings
- `src/Directory.Packages.props` → centralized package versions
- `src/.editorconfig` → compiler-integrated code style + formatting
- `src/StyleCopAnalyzers.Custom.ruleset` → code semantics, readability, and documentation rules
- `.github/workflows/dotnet-build-publish.yml` → Publish workflow
- `.github/workflows/dotnet-test.yml` → PR/push testing workflow

## Technology baseline

- .NET 10
- Language version default
- Nullable enabled
- Implicit usings enabled
- Central package management enabled
- Warnings treated as errors enabled
- Enforce code style in build enabled

### Dependencies

- SonarAnalyzer & StyleCop
- Microsoft Testing Platform
- NUnit v3 & NUnit Analyzer
- NSubstitute & NSubstitute Analyxer

## Coding rules

As per .editorconfig and StyleCop.

Also:

- Preserve existing naming.
- Prefer explicit, readable code over short clever code.
- Public APIs must include XML documentation written in English.
- Avoid breaking public API changes unless explicitly requested.
- Do not weaken nullability annotations.
- Do not silently change exception behavior.

## Library design rules

- Keep public API small and intentional.
- Favor immutability for public models.
- Validate all public method arguments.
- Prefer deterministic behavior and stable error messages.
- Do not add dependencies without a strong reason.
- No magic strings
- Minimise allocations

## Tests

- Add or update tests for every meaningful behavior change.
- Test names should follow the convention MethodName_Expectation_WhereClause, e.g. `IsEmpty_ThrowsArgumentNullException_WhenSourceIsNull()`.
- Favour longer, descriptive test names over minimising line length.
- Tests should be created in folder matching the directory structure of the source class being tested.
- Tests should be created in a class named `[SourceClassName]Tests.cs`.

  The exception to this is when the source class contains a significant number of members each requiring tests (e.g. extension methods). In this case, tests should be grouped in a subfolder named `/[SourceClassName]Tests/` and a class created for each member under test, e.g. `[MemberName]Tests.cs`.

- Cover happy path, guard clauses, and failure scenarios.
- Verify public API behavior, not implementation details, unless required.
- When fixing a bug, add a regression test first.
- Structure tests using the Arrange, Act, Assert pattern.
- Always use `Assert.That()` over `Assert.Equals()`
- Group multiple Asserts with `using (Assert.EnterMultipleScope()) {}`.
- If it is difficult to create a particular unit test. Don't. It is possible the code being tested needs rewriting instead.

## Documentation

- Update `README.md` when public behavior, public API, package metadata, or development workflow changes.
- Keep the README structure aligned with the repository standard.
- Keep installation instructions, target framework, badges, and package information accurate.
- Keep all examples compilable and aligned with the current API.
- Ensure usage examples reflect real and recommended library usage.
- Remove outdated or duplicate documentation when updating existing sections.

## Build and validation

Before considering work complete, run:

- `dotnet restore`
- `dotnet format`
- `dotnet build --configuration Release`
- `dotnet test --configuration Release`

## Packaging and versioning

- Package metadata must stay complete and consistent.
- README and icon must be included in the package.
- Changes affecting package contents must be reflected in versioning inputs.
- Do not change package id, repository url, or license without explicit request.

## Definition of "Done"

A change is done only when:

- Code is formatted,
- Code builds,
- Tests pass,
- Relevant tests were added or updated,
- README was updated if public behavior changed,
- No unnecessary files or dependencies were introduced.
