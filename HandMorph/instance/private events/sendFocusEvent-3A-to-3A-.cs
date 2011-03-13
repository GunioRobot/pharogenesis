sendFocusEvent: anEvent to: focusHolder
	"Send the event to the morph currently holding the focus"
	^focusHolder handleFocusEvent: 
		(anEvent transformedBy: (focusHolder transformedFrom: self)).