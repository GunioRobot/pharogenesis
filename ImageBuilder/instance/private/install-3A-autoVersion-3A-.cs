install: idString autoVersion: versionString 
	"private - SM 1.01 doesn't support installing or upgrading to a specific release 
	but ONLY if it isn't already installed. This is a hack that does that. 
	Next release of SM will have that ability. We use UUID and autoVersion 
	in order to be immune against package renamings or version name 
	renamings. No other checks are made here."
	| package release sm |
	sm := SMSqueakMap default.
	package := sm packageWithId: idString.
	release := package releaseWithAutomaticVersionString: versionString.
	(package isInstalled not
			or: [release newerThan: package installedRelease])
		ifTrue: [sm installPackageRelease: release].
	Transcript show: 'Installed ' , release printString;
		 cr