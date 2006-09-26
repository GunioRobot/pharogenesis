installPackageRelease: aRelease
	"Install a package release. The cache is used."

	| myRelease |
	aRelease isCompatibleWithCurrentSystemVersion ifFalse:
		[(self confirm:
'The package you are about to install is not listed as
being compatible with your image version (', SystemVersion current majorMinorVersion, '),
so the package may not work properly.
Do you still want to proceed with the install?')
			ifFalse: [^ self]].
	myRelease := self installedReleaseOfMe.
	[Cursor wait showWhile: [
		(SMInstaller forPackageRelease: aRelease) install.
		myRelease = self installedReleaseOfMe
					ifFalse: [self reOpen]
					ifTrue: [self noteChanged]]
	] on: Error do: [:ex |
		| msg |
		msg := ex messageText ifNil:[ex asString].
		self informException: ex msg: ('Error occurred during install:\', msg, '\') withCRs].