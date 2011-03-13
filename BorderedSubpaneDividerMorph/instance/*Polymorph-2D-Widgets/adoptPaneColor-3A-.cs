adoptPaneColor: paneColor
	"Match the color."
	
	super adoptPaneColor: paneColor.
	paneColor ifNil: [^self].
	self color: paneColor