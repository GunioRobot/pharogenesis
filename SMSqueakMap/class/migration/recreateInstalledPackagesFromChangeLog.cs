recreateInstalledPackagesFromChangeLog
	"Clear and recreate the Dictionary with information on installed packages.

	NOTE: This takes some time to run and will only find packages installed using SM
	and since the last changelog condense.

	For packages installed prior to SqueakMap 1.07 there is no timestamp nor counter
	logged. These packages will be given the time of the replay and a separate count
	(from -10000 upwards) maintaining correct order of installation."

	"SMSqueakMap recreateInstalledPackagesFromChangeLog"

	| changesFile chunk |
	SMSqueakMap default clearInstalledPackages.
	changesFile := (SourceFiles at: 2) readOnlyCopy.
	[changesFile atEnd]
		whileFalse: [
			chunk := changesFile nextChunk.
			((chunk beginsWith: '"Installed') and: [
				(chunk indexOfSubCollection: 'SMSqueakMap noteInstalledPackage:'
					startingAt: 10) > 0])
				ifTrue: [Compiler evaluate: chunk logged: false]].
	changesFile close