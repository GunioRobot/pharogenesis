on: eventName send: selector to: recipient
	eventHandler ifNil: [eventHandler _ EventHandler new].
	eventHandler on: eventName send: selector to: recipient