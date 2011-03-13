fullScreenOn

	self setProperty: #showingFullScreenMode toValue: true.
	ScreenController new fullScreenOn.
	self removeProperty: #currentNavigatorVersion.
	mouseInside _ false.
