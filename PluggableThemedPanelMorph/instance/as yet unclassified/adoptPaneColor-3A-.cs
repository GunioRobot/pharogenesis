adoptPaneColor: aColor
	"Set the pane color."
	
	super adoptPaneColor: aColor.
	aColor ifNil: [^self].
	self fillStyle: self normalFillStyle