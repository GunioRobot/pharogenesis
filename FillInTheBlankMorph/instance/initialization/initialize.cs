initialize
	super initialize.
	Preferences roundedWindowCorners ifTrue: [self useRoundedCorners].
	color _ Color white.
	borderWidth _ 2.
	self extent: 200@70.
	responseUponCancel _ ''.  "Caller can reset this to return something else, e.g. nil, upon cancel"
