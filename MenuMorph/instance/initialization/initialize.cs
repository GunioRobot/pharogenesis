initialize
	super initialize.
	self setDefaultParameters.
	orientation _ #vertical.
	hResizing _ #shrinkWrap.
	vResizing _ #shrinkWrap.
	defaultTarget _ nil.
	lastSelection _ nil.
	stayUp _ false.
	originalEvent _ nil.
	popUpOwner _ nil.
	Preferences roundedMenuCorners ifTrue: [self useRoundedCorners]
