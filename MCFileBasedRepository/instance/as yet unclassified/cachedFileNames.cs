cachedFileNames
	^cache == nil
		ifTrue: [#()]
		ifFalse: [cache keys]