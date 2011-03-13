changeSetList
	"Answer a list of ChangeSet names. If there're new
	ChangeSet instances, create a new list of change sets."

	ChangeSet instanceCount > AllChangeSets size
		ifTrue: [self class gatherChangeSets].
	^ AllChangeSets reversed collect: [:each | each name]