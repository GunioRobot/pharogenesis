toggleFullScreen
	ScreenController lastScreenModeSelected
		ifTrue: [ScreenController new fullScreenOff]
		ifFalse: [ScreenController new fullScreenOn].
	self world positionSubmorphs.
self class updateInstances