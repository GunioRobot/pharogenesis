undoOrRedoMenuWording
	"Answer the wording to be used in a menu item offering undo/redo"

	| pre |
	lastCommand ifNil: [^ 'can''t undo'].
	pre _ lastCommand phase == #done
		ifTrue:		['undo']
		ifFalse:		['redo'].
	^ ((pre, ' ', lastCommand cmdWording) truncateTo: 30), ' (z)'