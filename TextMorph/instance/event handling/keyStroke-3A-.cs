keyStroke: evt
	"Handle a keystroke event."
	| action |
	evt keyValue = 13 ifTrue:["CR - check for special action"
		action _ self crAction.
		action ifNotNil:[
			"Note: Code below assumes that this was some
			input field reacting on CR. Break the keyboard
			focus so that the receiver can be safely deleted."
			evt hand newKeyboardFocus: nil.
			^action value]].
	self handleInteraction: [editor readKeyboard] fromEvent: evt.
	"self updateFromParagraph."
	super keyStroke: evt  "sends to keyStroke event handler, if any"