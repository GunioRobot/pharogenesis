generateKeyboardEvent: evtBuf
	"Generate the appropriate mouse event for the given raw event buffer"

	| buttons modifiers type pressType stamp char |
	stamp := evtBuf second.
	stamp = 0 ifTrue: [stamp := Time millisecondClockValue].
	pressType := evtBuf fourth.
	pressType = EventKeyDown ifTrue: [type := #keyDown].
	pressType = EventKeyUp ifTrue: [type := #keyUp].
	pressType = EventKeyChar ifTrue: [type := #keystroke].
	modifiers := evtBuf fifth.
	buttons := modifiers bitShift: 3.
	char _ self keyboardInterpreter nextCharFrom: Sensor firstEvt: evtBuf.
	^ KeyboardEvent new
		setType: type
		buttons: buttons
		position: self position
		keyValue: char asciiValue
		hand: self
		stamp: stamp.
