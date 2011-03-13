removeLink: actionCode
	eventHandler ifNotNil:
		[eventHandler on: actionCode send: nil to: nil]