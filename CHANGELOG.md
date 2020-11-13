# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2020-11-13
### Added
- Added a new method for changing your voice using a custom pitch (fixes #2)
- Added a new method for controlling the music (fixes #3)
- Added a function to run custom commands without having to rely on the API
	- This function simply takes an integer instead of the XCommand enum, meaning if I'm too slow, you can still run the command yourself.
	- Though please add a new issue to the tracker so that I can update the wrapper accordingly.
- Added a static function for clamping, since this was only introduced in .NET Core 2

## Changed
- Moved enums into `Enums.cs`
- Changed the way `SendCommand` works by introducing a params array of objects. This allows for more than one argument to Clownfish commands
	- If anything breaks, please notify me with an issue
- Changed the README

## [1.0.0] - 2020-11-13
### Added
- Added this CHANGELOG file

[1.1.0] https://github.com/cozyGalvinism/AnemoneSharp/compare/1.0.0...1.1.0
[1.0.0] https://github.com/cozyGalvinism/AnemoneSharp/releases/tag/1.0.0