adoptPaneColor: paneColor
	"Pass on to the border too."
	
	super adoptPaneColor: paneColor.
	paneColor ifNil: [^self].
	self
		fillStyle: self fillStyleToUse;
		selectionColor: self selectionColor.
	self borderWidth > 0 ifTrue: [
		self borderStyle: self borderStyleToUse]