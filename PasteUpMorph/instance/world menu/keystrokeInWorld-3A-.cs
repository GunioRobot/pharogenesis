keystrokeInWorld: evt
	"A keystroke was hit when no keyboard focus was set, so it is sent here to the world instead."

	|  aChar isCmd ascii |
	aChar := evt keyCharacter.
	(ascii := aChar asciiValue) = 27 ifTrue: "escape key"
		[^ self putUpWorldMenuFromEscapeKey].
	(evt controlKeyPressed not
		and: [(#(1 4 8 28 29 30 31 32) includes: ascii)  "home, end, backspace, arrow keys, space"
			and: [self keyboardNavigationHandler notNil]])
				ifTrue: [self keyboardNavigationHandler navigateFromKeystroke: aChar].

	isCmd := evt commandKeyPressed and: [Preferences cmdKeysInText].
	
	(isCmd and: [Preferences honorDesktopCmdKeys]) ifTrue:
		[^ self dispatchCommandKeyInWorld: aChar event: evt].

	"It was unhandled. Remember the keystroke."
	self lastKeystroke: evt keyString.
	self triggerEvent: #keyStroke