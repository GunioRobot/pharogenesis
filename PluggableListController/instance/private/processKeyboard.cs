processKeyboard
	sensor keyboardPressed
		ifTrue: [view handleKeystroke: sensor keyboard]
		ifFalse: [super processKeyboard]