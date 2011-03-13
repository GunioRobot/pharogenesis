fullScreen
	"Expand the receiver to fill the screen (except for modest allowances).  6/6/96 sw"

	self isCollapsed ifFalse:
		[self reframeTo: (Rectangle origin: (40@2) extent: (DisplayScreen actualScreenSize - (42@4)))]