# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Unreleased

### Fixed

- Parameter prefixes looked like PC_1.000 instead of PC_001

## [0.2.3] - 2025-10-16

### Added

- This changelog
- A license

### Changed

- Hide the icon of the ProceduralControllerBuilder by default
- Rename the assembly definitions

## [0.2.2] - 2025-10-14

### Added

- Tooltips for the ProceduralControllerBuilder editor
- An icon for the Full Controller asset

### Changed

- Allow use of VRCSDK 3.9.x
- Allow a custom icon to be set for the root menu of a procedural controller
- Move examples into a Sample Templates folder

## [0.2.1] - 2025-09-15

### Changed

- Update the Core dependency to 0.8.0

## [0.2.0] - 2025-09-09

### Added

- An icon for ProceduralControllerBuilder

### Changed

- **BREAKING**: Rename the package
- **BREAKING**: Switch over to upgradable data
- Use correct prefixes for CreateAssetMenu attributes
- Rename ProceduralControllerSetup to ProceduralControllerBuilder

## [0.1.0] - 2025-03-20

### Fixed

- Correct an invalid assembly definiton

## [0.1.0] - 2025-03-20

### Added

- A basic DI system to locate "processors" that can interpret "models"
- Asset models and component models