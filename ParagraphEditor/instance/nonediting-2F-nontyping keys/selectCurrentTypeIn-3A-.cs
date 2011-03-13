selectCurrentTypeIn: characterStream 
	"Select what would be replaced by an undo (e.g., the last typeIn)."

	| prior |

	self closeTypeIn: characterStream.
	prior := otherInterval.
	self closeTypeIn: characterStream.
	self selectInterval: UndoInterval.
	otherInterval := prior.
	^ true