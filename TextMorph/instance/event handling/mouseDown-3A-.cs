mouseDown: evt 
	"Make this TextMorph be the keyboard input focus, if it isn't  
	already, and repond to the text selection gesture."
	evt yellowButtonPressed
		ifTrue: ["First check for option (menu) click"
			^ self yellowButtonActivity: evt shiftPressed].
	evt hand newKeyboardFocus: self.
	self
		handleInteraction: [editor mouseDown: evt]
		fromEvent: evt.
