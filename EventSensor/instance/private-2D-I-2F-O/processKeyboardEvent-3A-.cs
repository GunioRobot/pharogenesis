processKeyboardEvent: evt
	"process a keyboard event, updating InputSensor state"
	| charCode pressCode |
	"Never update keyboardBuffer if we have an eventQueue active"
	mouseButtons := (mouseButtons bitAnd: 7) bitOr: ((evt at: 5) bitShift: 3).
	eventQueue ifNotNil:[^self]. 
	charCode := evt at: 3.
	charCode isNil ifTrue:[^self]. "extra characters not handled in MVC"
	pressCode := evt at: 4.
	pressCode = EventKeyChar ifFalse:[^self]. "key down/up not handled in MVC"
	"mix in modifiers"
	charCode := charCode bitOr: ((evt at: 5) bitShift: 8).
	keyboardBuffer nextPut: charCode.