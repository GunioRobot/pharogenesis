hasSubmorphWithProperty: aSymbol
	submorphs detect: [:m | m hasProperty: aSymbol] ifNone: [^ false].
	^ true