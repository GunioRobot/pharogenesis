primKbdNext
	"Allows for use of old Sensor protocol to get at the keyboard,
	as when running kbdTest or the InterpreterSimulator in Morphic"
	| evtBuf |
	self fetchMoreEvents.
	keyboardBuffer isEmpty ifFalse:[^ keyboardBuffer next].
	eventQueue ifNotNil:
		[evtBuf _ eventQueue nextOrNilSuchThat: [:buf | self isKbdEvent: buf].
		self flushNonKbdEvents].
	^ evtBuf ifNotNil: [evtBuf at: 3]
