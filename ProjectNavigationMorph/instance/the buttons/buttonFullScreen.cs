buttonFullScreen

	^self inFullScreenMode ifTrue: [
		self makeButton: 'Browser Reentry' balloonText: 'Re-enter the browser' for: #fullScreenOff
	] ifFalse: [
		self makeButton: 'Escape Browser' balloonText: 'Use the full screen' for: #fullScreenOn
	]

