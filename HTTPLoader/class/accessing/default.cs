default
	DefaultLoader ifNil: [
		DefaultLoader _ HTTPLoader new].
	^DefaultLoader