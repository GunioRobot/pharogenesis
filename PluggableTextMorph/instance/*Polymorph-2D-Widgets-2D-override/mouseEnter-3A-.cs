mouseEnter: event
	"Changed to take mouseClickForKeyboardFocus preference into account."
	
	super mouseEnter: event.
	self textMorph ifNil: [^self].
	selectionInterval ifNotNil:
		[self textMorph editor selectInterval: selectionInterval; setEmphasisHere].
	self textMorph selectionChanged.
	self wantsKeyboardFocus ifFalse: [^self].
	Preferences mouseClickForKeyboardFocus
		ifFalse: [self textMorph takeKeyboardFocus]