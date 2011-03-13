handlesMouseDown: evt
	"If the shift key is pressed then yes.
	As normal if the editableStringMorphs preference is false."
	
	^(Preferences editableStringMorphs and: [
			evt shiftPressed and: [self wantsKeyboardFocusOnShiftClick]])
		ifTrue: [true]
		ifFalse: [super handlesMouseDown: evt]