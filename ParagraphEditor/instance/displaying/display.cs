display
	"Redisplay the paragraph."

	| selectionState |
	selectionState _ selectionShowing.
	self deselect.
	paragraph foregroundColor: view foregroundColor
			backgroundColor: view backgroundColor;
			displayOn: Display.
	selectionState ifTrue: [self select]