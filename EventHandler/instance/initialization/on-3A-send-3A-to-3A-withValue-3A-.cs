on: eventName send: selector to: recipient withValue: value
	selector numArgs = 3 ifFalse:
		[self halt: 'Warning: value parameters are passed as last of 3 arguments'].
	self on: eventName send: selector to: recipient.
	valueParameter _ value
