adoptPaneColor: paneColor
	"Pass on to the border too."
	
	super adoptPaneColor: paneColor.
	paneColor ifNil: [^self].
	self borderStyle baseColor: (self enabled ifTrue: [paneColor twiceDarker] ifFalse: [paneColor darker])