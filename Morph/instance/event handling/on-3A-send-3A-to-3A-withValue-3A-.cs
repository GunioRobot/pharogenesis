on: eventName send: selector to: recipient withValue: value
	"NOTE: selector must take 3 arguments, of which value will be the 3rd"
	eventHandler ifNil: [eventHandler _ EventHandler new].
	eventHandler on: eventName send: selector to: recipient withValue: value
