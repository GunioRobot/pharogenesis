selectCurrentTypeIn: characterStream 
	"Select what would be replaced by an undo (e.g., the last typeIn)."

	| prior |

	prior _ otherInterval.
	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.
	self selectInterval: UndoInterval.
	otherInterval _ prior.
	^ true