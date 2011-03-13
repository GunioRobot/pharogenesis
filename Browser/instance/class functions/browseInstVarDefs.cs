browseInstVarDefs 

	classListIndex = 0 ifTrue: [^ self].
	self selectedClassOrMetaClass browseInstVarDefs