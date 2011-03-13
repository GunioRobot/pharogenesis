gatherAllChangesExceptSystemChangesIntoCurrentChangeSet
	"Gather together into the current changeSet all the changes in all change sets except for the one named 'System Changes'.  1/22/96 sw"

	| currentChanges systemChanges |
	self flag: #scottPrivate.
	currentChanges _ Smalltalk changes.
	systemChanges _ ChangeSorter changeSetNamed: 'System Changes'.
	ChangeSet allInstancesDo:
		[:aChangeSet | ((aChangeSet ~~ currentChanges) and:
			[aChangeSet ~~ systemChanges])
				ifTrue:
					[currentChanges assimilateAllChangesFoundIn: aChangeSet.
					Transcript cr; show: 'Changes in ', aChangeSet name, ' copied.']]

"SystemBuilder gatherAllChangesExceptSystemChangesIntoCurrentChangeSet"