changeSetList

	ChangeSet instanceCount > AllChangeSets size ifTrue: [self class gatherChangeSets].
	^ AllChangeSets reversed collect: [:each | each name]