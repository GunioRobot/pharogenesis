processKeyboardEvent: evt
	"process a keyboard event, updating InputSensor state"
	| charCode pressCode |
	"Never update keyboardBuffer if we have an eventQueue active"
	mouseButtons _ (mouseButtons bitAnd: 7) bitOr: ((evt at: 5) bitShift: 3).
	eventQueue ifNotNil:[^self]. 
	charCode _ evt at: 3.
	charCode = nil ifTrue:[^self]. "extra characters not handled in MVC"
	pressCode _ evt at: 4.
	pressCode = EventKeyChar ifFalse:[^self]. "key down/up not handled in MVC"
	"mix in modifiers"
	charCode _ charCode bitOr: ((evt at: 5) bitShift: 8).
	keyboardBuffer nextPut: charCode.