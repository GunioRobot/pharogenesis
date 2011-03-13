initialize
"initialize the state of the receiver"
	super initialize.
""
	cursor := 1.
	padding := 3.
	self enableDragNDrop.
	self clipSubmorphs: true