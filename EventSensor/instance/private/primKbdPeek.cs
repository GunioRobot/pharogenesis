primKbdPeek
	"Allows for use of old Sensor protocol to get at the keyboard,
	as when running kbdTest or the InterpreterSimulator in Morphic"
	| char |
	self fetchMoreEvents.
	keyboardBuffer isEmpty ifFalse: [^ keyboardBuffer peek].
	char _ nil.
	eventQueue ifNotNil:
		[eventQueue nextOrNilSuchThat:  "NOTE: must not return out of this block, so loop to end"
			[:buf | (self isKbdEvent: buf) ifTrue: [char ifNil: [char _ buf at: 3]].
			false  "NOTE: block value must be false so Queue won't advance"]].
	^ char