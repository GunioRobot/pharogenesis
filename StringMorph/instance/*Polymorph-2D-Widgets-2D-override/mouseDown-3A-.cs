mouseDown: evt
	"If the shift key is pressed, make this string the keyboard input focus.
	Process as normal if the editableStringMorphs preference is false."

	(Preferences editableStringMorphs and: [
			evt shiftPressed and: [self wantsKeyboardFocusOnShiftClick]])
		ifTrue: [self launchMiniEditor: evt]
		ifFalse: [super mouseDown: evt].
