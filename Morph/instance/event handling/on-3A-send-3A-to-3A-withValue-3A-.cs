on: eventName send: selector to: recipient withValue: value
	"NOTE: selector must take 3 arguments, of which value will be the 3rd"

	self eventHandler ifNil: [self eventHandler: EventHandler new].
	self eventHandler on: eventName send: selector to: recipient withValue: value
