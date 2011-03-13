fullScreen   "Display fullScreen"

	ScreenSave notNil ifTrue: [Display _ ScreenSave].
	clippingBox _ super boundingBox