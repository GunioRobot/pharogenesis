mouseDown: evt
	"Make this TextMorph be the keyboard input focus, if it isn't already,
		and repond to the text selection gesture."

	evt hand newKeyboardFocus: self.
	self handleInteraction: [editor mouseDown: evt] fromEvent: evt