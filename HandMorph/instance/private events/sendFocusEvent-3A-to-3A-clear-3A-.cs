sendFocusEvent: anEvent to: focusHolder clear: aBlock
	"Send the event to the morph currently holding the focus"
	| result w |
	w _ focusHolder world ifNil:[^ aBlock value].
	w becomeActiveDuring:[
		ActiveHand _ self.
		ActiveEvent _ anEvent.
		result _ focusHolder handleFocusEvent: 
			(anEvent transformedBy: (focusHolder transformedFrom: self)).
	].
	^result