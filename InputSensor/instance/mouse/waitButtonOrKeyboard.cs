waitButtonOrKeyboard
	"Wait for the user to press either any mouse button or any key.
	Answer the current cursor location or nil if a keypress occured."

	[self anyButtonPressed] whileFalse:
		[(Delay forMilliseconds: 50) wait.
		self keyboardPressed ifTrue: [^ nil]].
	^ self cursorPoint