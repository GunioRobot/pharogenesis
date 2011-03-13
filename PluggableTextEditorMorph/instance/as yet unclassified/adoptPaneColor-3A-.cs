adoptPaneColor: paneColor
	"Use the theme for fillStyle and border."
	
	super adoptPaneColor: paneColor.
	paneColor ifNil: [^self].
	self fillStyle: self fillStyleToUse.
	self borderWidth > 0 ifTrue: [
		self borderStyle: self borderStyleToUse]