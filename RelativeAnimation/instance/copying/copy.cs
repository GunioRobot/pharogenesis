copy
	"Creates a copy of the animation"

	| anim |

	anim _ RelativeAnimation new.

	anim object: animatedObject
		update: updateFunction
		getStartState: getStartStateFunction
		getEndState: getEndStateFunction
		getReverseState: getReverseStateFunction 
		style: styleFunction
		duration: duration
		undoable: undoable
		inWonderland: myWonderland.

	(direction = Forward) ifFalse: [ anim reverseDirection ].

	^ anim.
