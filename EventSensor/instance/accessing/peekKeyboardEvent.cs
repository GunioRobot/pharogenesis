peekKeyboardEvent
	"Return the next keyboard char event from the receiver or nil if none available"
	^eventQueue nextOrNilSuchThat: 
					[:buf | 
					buf first = EventTypeKeyboard and: [(buf fourth) = EventKeyChar]]