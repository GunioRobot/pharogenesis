useChangeSetNamed: baseName during: aBlock
	"Use the named change set, or create one with the given name."
	| changeHolder oldChanges newChanges |
	changeHolder := (ChangeSet respondsTo: #newChanges:)
						ifTrue: [ChangeSet]
						ifFalse: [Smalltalk].
	oldChanges := (ChangeSet respondsTo: #current)
						ifTrue: [ChangeSet current]
						ifFalse: [Smalltalk changes].

	newChanges := (ChangeSorter changeSetNamed: baseName) ifNil: [ ChangeSet new name: baseName ].
	changeHolder newChanges: newChanges.
	[aBlock value] ensure: [changeHolder newChanges: oldChanges].
