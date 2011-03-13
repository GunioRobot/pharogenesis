localHandleKeystroke: evt
	"Answer whether we locally handle the keyStroke event.
	Disregard tabs for now."
	
	evt keyCharacter = Character tab ifTrue: [
		evt shiftPressed
			ifTrue: [(self editView respondsTo: #navigateFocusBackward)
						ifTrue: [self editView navigateFocusBackward]]
			ifFalse: [(self editView respondsTo: #navigateFocusForward)
						ifTrue: [self editView navigateFocusForward]].
		^true].
	^false