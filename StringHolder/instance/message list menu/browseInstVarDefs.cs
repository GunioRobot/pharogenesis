browseInstVarDefs 

	| cls |
	(cls _ self selectedClassOrMetaClass) ifNotNil: [self systemNavigation browseInstVarDefs: cls]