undoIt
	"Set the object's color back to its original value"

	| anim |

	anim _ theActor setColor: originalColor duration: 0.5.
	anim setUndoable: false.
