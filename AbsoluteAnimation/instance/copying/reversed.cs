reversed
	"Creates a reversed version of an animation"

	| anim |

	anim _ AbsoluteAnimation new.

	anim object: animatedObject
		update: updateFunction
		getStartState: getStartStateFunction
		getEndState: getEndStateFunction
		style: styleFunction
		duration: duration
		undoable: true
		inWonderland: myWonderland.

	anim stop.
	(direction = Forward) ifTrue: [ anim reverseDirection ].

	^ anim.
