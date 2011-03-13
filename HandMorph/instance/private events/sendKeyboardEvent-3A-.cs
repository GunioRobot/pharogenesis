sendKeyboardEvent: anEvent 
	"Send the event to the morph currently holding the focus, or if none to
	the owner of the hand."
	ServiceShortcuts handleKeystroke: anEvent.
	^ self
		sendEvent: anEvent
		focus: self keyboardFocus
		clear: [self keyboardFocus: nil]