adoptPaneColor: paneColor
	"Change our color too."
	
	super adoptPaneColor: paneColor.
	paneColor ifNil: [^self].
	self
		valueOfProperty: #fillStyle
		ifAbsent: [self color: paneColor].
	self borderStyle baseColor: paneColor darker