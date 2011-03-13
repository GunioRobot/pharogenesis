selectConflicts
	"Selects all method definitions for which there is ALSO an entry in changes"
	| change class systemChanges |
	Cursor read showWhile: 
	[1 to: changeList size do:
		[:i | change _ changeList at: i.
		listSelections at: i put:
			(change type = #method
			and: [(class _ change methodClass) notNil
			and: [(Smalltalk changes atSelector: change methodSelector
						class: class) ~~ #none]])]].
	self changed: #allSelections