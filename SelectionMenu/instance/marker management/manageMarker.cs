manageMarker
	"Returns the selected item. If no selection, return nil."

	super manageMarker.
	(selections = nil or: [(selection between: 1 and: selections size) not])
		ifTrue: [^ nil].
	^ selections at: selection