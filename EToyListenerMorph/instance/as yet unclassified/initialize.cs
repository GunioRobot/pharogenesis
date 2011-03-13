initialize

	super initialize.
	self listDirection: #topToBottom.
	color _ Color lightBlue.
	self layoutInset: 4.
	borderColor _ Color blue.
	borderWidth _ 4.
	self rebuild.
