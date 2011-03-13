display
	"Redisplay the paragraph."

	| selectionState view |
	self haltOnce.
	selectionState := selectionShowing.
	self deselect.
	paragraph foregroundColor: view foregroundColor
			backgroundColor: view backgroundColor;
			displayOn: Display.
	selectionState ifTrue: [self select]