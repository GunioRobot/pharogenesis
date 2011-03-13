adaptToWorld: aWorld
	"If any of my recipients refer to a world or a hand, make them now refer
	to the corresponding items in the new world.  (instVarNamed: is slow, later
	use perform of two selectors.)"

	| value newValue |
	#(mouseDownRecipient mouseStillDownRecipient mouseUpRecipient
	mouseEnterRecipient mouseLeaveRecipient mouseEnterDraggingRecipient
	mouseLeaveDraggingRecipient clickRecipient doubleClickRecipient startDragRecipient keyStrokeRecipient valueParameter) do:
		[:aName |
		(value _ self instVarNamed: aName asString) ifNotNil:[
			newValue _ value adaptedToWorld: aWorld.
			(newValue notNil and: [newValue ~~ value])
				ifTrue:
					[self instVarNamed: aName asString put: newValue]]]