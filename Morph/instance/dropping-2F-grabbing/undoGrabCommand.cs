undoGrabCommand
	"Return the undo command for grabbing the receiver"
	| cmd |
	owner ifNil:[^nil]. "no owner - no undo"
	^(cmd _ Command new)
		cmdWording: 'move ', (String streamContents: [:s | self printOn: s] limitedTo: 18);
		undoTarget: self
		selector: #undoMove:redo:owner:bounds:predecessor:
		arguments: {cmd. false. owner. self bounds. (owner morphPreceding: self)}