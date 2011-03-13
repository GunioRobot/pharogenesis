initialize

	super initialize.
	groupMode _ true.
	color _ Color paleRed.
	self listDirection: #topToBottom.
	self layoutInset: 10.
	borderColor _ #raised.
	borderWidth _ 4.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self setProperty: #normalBorderColor toValue: borderColor.
	self setProperty: #flashingColors toValue: {Color red. Color yellow}.
	self rebuild.
