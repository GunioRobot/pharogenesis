copyFileNamed: srcName to: dstName 
	| dstEntry srcEntry |
	dstEntry _ FileDirectory directoryEntryFor: dstName.
	dstEntry ifNotNil:[
		srcEntry _ FileDirectory directoryEntryFor: srcName.
		srcEntry ifNil:[^self couldNotOpenFile: srcName].
		dstEntry modificationTime >= srcEntry modificationTime ifTrue:[^self].
	].
	logger show:'==> ', dstName; cr.
	^self primitiveCopyFileNamed: srcName to: dstName 