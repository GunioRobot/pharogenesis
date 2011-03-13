themeChanged
	"Update the selection colour."

	self selectionColor ifNotNil: [
		self selectionColor: self theme selectionColor].
	self layoutInset: (self theme dropListInsetFor: self).
	self buttonMorph extent: self buttonExtent.
	super themeChanged