undoIt
	"Move the object back to its original position"

	| anim |

	anim _ theActor setSize: originalSize duration: 0.5.
	anim setUndoable: false.
