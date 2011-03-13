initialize
	super initialize.
	bounds _ 0@0 corner: 40@10.
	self setDefaultParameters.
	self listDirection: #topToBottom.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	defaultTarget _ nil.
	selectedItem _ nil.
	stayUp _ false.
	popUpOwner _ nil.
	Preferences roundedMenuCorners ifTrue: [self useRoundedCorners]
