initialize

	super initialize.
	self listDirection: #topToBottom.
	color _ Color lightBrown.
	self layoutInset: 4.
	borderColor _ #raised "Color brown".
	borderWidth _ 4.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self useRoundedCorners.

	self rebuild.
	