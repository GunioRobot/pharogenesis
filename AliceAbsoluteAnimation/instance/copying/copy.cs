copy
	"Creates a copy of the animation"

	| anim |

	anim _ AliceAbsoluteAnimation new.

	anim object: animatedObject
		update: updateFunction
		getStartState: getStartStateFunction
		getEndState: getEndStateFunction
		style: styleFunction
		duration: duration
		undoable: undoable
		inWonderland: myWonderland.

	(direction = Forward) ifFalse: [ anim reverseDirection ].

	^ anim.
