initialize
	super initialize.

	bounds := 0 @ 0 corner: 40 @ 10.

	self setDefaultParameters.

	self listDirection: #topToBottom.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	defaultTarget := nil.
	selectedItem := nil.
	stayUp := false.
	popUpOwner := nil.
	self setProperty: #morphicLayerNumber toValue: self morphicLayerNumber.
	Preferences roundedMenuCorners
		ifTrue: [self useRoundedCorners].
