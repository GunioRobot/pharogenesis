buttonHeight
	^ self hasButton
		ifTrue: [button height]
		ifFalse: [self defaultButtonHeight]
