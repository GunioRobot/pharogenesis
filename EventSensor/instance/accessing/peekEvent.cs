peekEvent
	"Look ahead at the next event."
	eventQueue == nil 
		ifTrue:[^ nil]
		ifFalse:[^ eventQueue peek]
