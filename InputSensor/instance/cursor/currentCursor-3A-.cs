currentCursor: newCursor 
	"Set newCursor to be the displayed Cursor form."

	CurrentCursor _ newCursor.
	Cursor currentCursor: CurrentCursor.