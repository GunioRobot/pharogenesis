undoIt
	"Move the object back to its original position"

	| anim |

	anim _ theActor moveTo: originalPosition duration: 0.5.
	anim setUndoable: false.
