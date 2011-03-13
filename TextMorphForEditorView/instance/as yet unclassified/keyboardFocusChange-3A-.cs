keyboardFocusChange: aBoolean 
	"If we are losing focus and have acceptOnFocusChange then accept."
	
	super keyboardFocusChange: aBoolean.
	self acceptOnFocusChange
		ifTrue: [self editView hasUnacceptedEdits ifTrue: [self editor accept]]