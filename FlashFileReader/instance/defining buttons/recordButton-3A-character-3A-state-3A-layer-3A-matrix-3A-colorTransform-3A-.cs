recordButton: buttonId character: characterId state: state layer: layer matrix: matrix colorTransform: cxForm
	"Define the character to use for a button.
		buttonId:	global ID used for the button
		characterId:	ID of the character defining the shape for the button
		state:		bit mask for when to use the character
						1 - default (e.g. no other state applies)
						2 - display when the mouse is over the button but not pressed
						4 - display when the button is pressed
						8 - the area in which the mouse is supposed to be 'over' the button
		layer:		UNKNOWN.
		matrix:		Transformation to apply to the character. (Guess!)"