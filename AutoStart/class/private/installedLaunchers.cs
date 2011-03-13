installedLaunchers
	InstalledLaunchers ifNil: [
		InstalledLaunchers _ OrderedCollection new].
	^InstalledLaunchers