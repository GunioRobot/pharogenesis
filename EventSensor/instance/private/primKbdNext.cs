primKbdNext
	keyboardBuffer isEmpty
		ifTrue:[^nil]
		ifFalse:[^keyboardBuffer next]