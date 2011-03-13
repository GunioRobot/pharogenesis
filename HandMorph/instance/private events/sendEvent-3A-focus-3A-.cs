sendEvent: anEvent focus: focusHolder
	"Send the event to the morph currently holding the focus, or if none to the owner of the hand."
	focusHolder ifNil:[^owner processEvent: anEvent].
	^self sendFocusEvent: anEvent to: focusHolder.