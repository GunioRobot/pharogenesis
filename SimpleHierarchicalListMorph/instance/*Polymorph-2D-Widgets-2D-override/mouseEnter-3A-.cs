mouseEnter: event
	"Changed to take mouseClickForKeyboardFocus preference into account."
	
	super mouseEnter: event.
	self wantsKeyboardFocus ifFalse: [^self].
	Preferences mouseClickForKeyboardFocus
		ifFalse: [self takeKeyboardFocus]