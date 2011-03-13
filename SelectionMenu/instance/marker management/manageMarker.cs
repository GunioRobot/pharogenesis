manageMarker
	"Returns the selected item, or else the last selection
	2/4/96 sw: if no selection, return nil"

	super manageMarker.
	selection = 0 ifTrue: [^ nil].
	^ selections at: selection