click: event fromMorph: sourceMorph 
	"This message is sent only when double clicks are handled."
	^ self
		send: mouseDownSelector
		to: mouseDownRecipient
		withEvent: event
		fromMorph: sourceMorph