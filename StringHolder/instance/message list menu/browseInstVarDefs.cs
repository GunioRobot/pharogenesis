browseInstVarDefs 

	| cls |
	(cls _ self selectedClassOrMetaClass) ifNotNil: [cls browseInstVarDefs]