makeUndoVersion
	"Creates the undo version of an animation"

	| anim |

	anim _ AliceAbsoluteAnimation new.

	anim object: animatedObject
		update: updateFunction
		getStartState: getStartStateFunction
		getEndState: getEndStateFunction
		style: styleFunction
		duration: 0.5
		undoable: false
		inWonderland: myWonderland.

	anim stop.
	(direction = Forward) ifTrue: [ anim reverseDirection ].

	^ anim.
