sliderShadowColor
	^ self roundedScrollbarLook
		ifTrue: [self sliderColor darker]
		ifFalse: [super sliderShadowColor]
