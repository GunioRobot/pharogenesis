adoptPaneColor: aColor
	"Adopt the given pane color"
	self alternativeScrollbarLook ifFalse:[^self].
	aColor ifNil:[^self].
	self sliderColor: aColor.