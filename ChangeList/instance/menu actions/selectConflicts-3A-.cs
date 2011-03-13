selectConflicts: changeSetOrList
	"Selects all method definitions for which there is ALSO an entry in the specified changeSet or changList"
	| change class systemChanges |
	Cursor read showWhile: 
	[(changeSetOrList isKindOf: ChangeSet) ifTrue: [
	1 to: changeList size do:
		[:i | change _ changeList at: i.
		listSelections at: i put:
			(change type = #method
			and: [(class _ change methodClass) notNil
			and: [(changeSetOrList atSelector: change methodSelector
						class: class) ~~ #none]])]]
	ifFalse: ["a ChangeList"
	1 to: changeList size do:
		[:i | change _ changeList at: i.
		listSelections at: i put:
			(change type = #method
			and: [(class _ change methodClass) notNil
			and: [changeSetOrList list includes: (list at: i)]])]]
	].
	self changed: #allSelections