initialize

	super initialize.
	self setDefaultParameters.
	self extent: 400 @ 150.
	responseUponCancel := ''.
	Preferences roundedMenuCorners
		ifTrue: [self useRoundedCorners].
	