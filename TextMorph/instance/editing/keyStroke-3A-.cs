keyStroke: evt
	"Handle a keystroke event."
	self handleInteraction: [editor readKeyboard] fromEvent: evt.
	self updateFromParagraph