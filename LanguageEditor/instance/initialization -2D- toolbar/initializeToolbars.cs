initializeToolbars
	"initialize the receiver's toolbar"
	self
		addMorph: self createMainToolbar
		frame: (0 @ 0 corner: 1 @ 0.09).
	""
	self
		addMorph: self createTranslationsToolbar
		frame: (0 @ 0.09 corner: 0.5 @ 0.18).
	self
		addMorph: self createUntranslatedToolbar
		frame: (0.5 @ 0.09 corner: 1 @ 0.18)