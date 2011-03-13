nextKeyboardEvent
	"Allows for use of old Sensor protocol to get at the keyboard,
	as when running kbdTest or the InterpreterSimulator in Morphic"

	| evtBuf |
	evtBuf := eventQueue nextOrNilSuchThat: [:buf | self isKbdEvent: buf].
	self flushNonKbdEvents.
	^evtBuf