fullScreenOff

	self setProperty: #showingFullScreenMode toValue: false.
	ScreenController new fullScreenOff.
	self removeProperty: #currentNavigatorVersion.
	mouseInside _ false.
