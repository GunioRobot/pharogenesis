useNewChangeSetDuring: aBlock
	| changeHolder oldChanges newChanges |
	changeHolder _ (ChangeSet respondsTo: #newChanges:)
						ifTrue: [ChangeSet]
						ifFalse: [Smalltalk].
	oldChanges _ (ChangeSet respondsTo: #current)
						ifTrue: [ChangeSet current]
						ifFalse: [Smalltalk changes].

	newChanges _ ChangeSet new name: (ChangeSet uniqueNameLike: self extractPackageName).
	changeHolder newChanges: newChanges.
	[aBlock value] ensure: [changeHolder newChanges: oldChanges].