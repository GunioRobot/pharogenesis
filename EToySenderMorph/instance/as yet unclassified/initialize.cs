initialize

	Socket initializeNetwork.				"we may want our IP address"
	Preferences defaultAuthorName.		"seems like a good place to insure we have a name"
	super initialize.
	self listDirection: #topToBottom.
	color _ Color lightMagenta.
	self layoutInset: 4.
	borderColor _ Color magenta.
	borderWidth _ 4.
	self setProperty: #normalBorderColor toValue: borderColor.
	self setProperty: #flashingColors toValue: {Color red. Color yellow}.

