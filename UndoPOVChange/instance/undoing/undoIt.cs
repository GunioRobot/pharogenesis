undoIt
	"Set the object's POV back to its original value"

	| anim |

	anim _ theActor setPointOfView: originalPOV duration: 0.5.
	anim setUndoable: false.
