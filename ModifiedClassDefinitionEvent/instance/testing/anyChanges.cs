anyChanges
	^ self isSuperclassModified or: [self areInstVarsModified or: [self areClassVarsModified or: [self areSharedPoolsModified]]]