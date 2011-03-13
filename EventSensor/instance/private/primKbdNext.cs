primKbdNext
	"Allows for use of old Sensor protocol to get at the keyboard,
	as when running kbdTest or the InterpreterSimulator in Morphic"
	| evtBuf |
	self wait2ms.
	self fetchMoreEvents.
	keyboardBuffer isEmpty ifFalse:[^ keyboardBuffer next].
	evtBuf := self eventQueue nextOrNilSuchThat: [:buf | self isKbdEvent: buf].
	self flushNonKbdEvents.
	^ evtBuf ifNotNil: [evtBuf at: 6]