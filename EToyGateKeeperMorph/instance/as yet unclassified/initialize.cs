initialize

	super initialize.
	self listDirection: #topToBottom.
	color _ Color lightGray.
	self layoutInset: 4.
	borderColor _ #raised "Color brown".
	borderWidth _ 4.
	self hResizing: #spaceFill.
	self vResizing: #spaceFill.
	self useRoundedCorners.

	self rebuild.
	