paintArea
	"What rectangle should the user be allowed to create a new painting in??  An area beside the paintBox.  Allow playArea to override with its own bounds!  "

	| paintBoxBounds |
	paintBoxBounds _ self paintBox bounds.
	self hands first targetOffset x < paintBoxBounds center x
		ifTrue: [^ bounds topLeft corner: paintBoxBounds left@bounds bottom]   "paint on left side"
		ifFalse: [^ paintBoxBounds right@bounds top corner: bounds bottomRight].  "paint on right side"
