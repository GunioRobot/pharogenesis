handleInteraction: interActionBlock fromEvent: evt
	self installEditor.  "Make sure editor is installed"
	editor sensor: (KeyboardBuffer new startingEvent: evt).  "Fool MVC"
	self selectionChanged.  "Note old selection"

		interActionBlock value.

	self selectionChanged.  "Note new selection"