undoIt
	"Set the object's visibility back to its original value"

	| anim |

	anim _ theActor setVisibility: originalVisibility duration: 0.5.
	anim setUndoable: false.
