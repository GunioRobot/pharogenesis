defaultBackgroundColor
	"Answer the color to be used as the base window color."
	
	^self theme
		windowColorFor: (self model ifNil: [self])