makeUndoVersion
	"Creates the undo version of an animation"

	| anim |

	anim _ RelativeAnimation new.

	anim object: animatedObject
		update: updateFunction
		getStartState: getStartStateFunction
		getEndState: getEndStateFunction
		getReverseState: getReverseStateFunction 
		style: styleFunction
		duration: 0.5
		undoable: false
		inWonderland: myWonderland.

	anim stop.
	(direction = Forward) ifTrue: [ anim reverseDirection ].

	^ anim.
