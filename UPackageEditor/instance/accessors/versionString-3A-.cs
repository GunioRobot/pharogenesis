versionString: aString
	package version: (UVersion readFromString: aString).
	self changed: #versionString.
	^true