initialize

	super initialize.
	turtleCount _ 1.
	self assuredPlayer assureUniClass.
	self extent: 40@40.

	isGroup _ false.
	self color: self saturatedRandomColor.

