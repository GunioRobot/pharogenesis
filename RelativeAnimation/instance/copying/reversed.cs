reversed
	"Creates a reversed version of an animation"

	| anim |

	anim _ RelativeAnimation new.

	anim object: animatedObject
		update: updateFunction
		getStartState: getStartStateFunction
		getEndState: getEndStateFunction
		getReverseState: getReverseStateFunction 
		style: styleFunction
		duration: duration
		undoable: true
		inWonderland: myWonderland.

	anim stop.
	(direction = Forward) ifTrue: [ anim reverseDirection ].

	^ anim.
