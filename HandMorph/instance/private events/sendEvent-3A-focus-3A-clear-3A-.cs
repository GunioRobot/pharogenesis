sendEvent: anEvent focus: focusHolder clear: aBlock
	"Send the event to the morph currently holding the focus, or if none to the owner of the hand."
	| result |
	focusHolder ifNotNil:[^self sendFocusEvent: anEvent to: focusHolder clear: aBlock].
	ActiveEvent _ anEvent.
	result _ owner processEvent: anEvent.
	ActiveEvent _ nil.
	^result