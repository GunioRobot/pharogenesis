processKeyboard
	"Determine whether the user pressed the keyboard, and if the character is
	understood as a command"

	| char selector |
	sensor keyboardPressed
		ifTrue:
			[char _ sensor keyboard.
			selector _ ContextStackKeyboardCommands
				at: char
				ifAbsent: [nil].
			selector isNil
				ifTrue: [view flash]
				ifFalse: [self perform: selector]]