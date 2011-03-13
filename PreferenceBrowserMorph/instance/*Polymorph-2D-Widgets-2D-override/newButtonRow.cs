newButtonRow
	"Answer a new button row."
	
	^(UITheme builder newToolDockingBar addMorph: (
		(UITheme builder newRow: {
			self defaultButton.
			self newSeparator.
			self saveButton.
			self loadButton.
			self themeButton.
			self newSeparator.
			self saveToDiskButton.
			self loadFromDiskButton.
			self newTransparentFiller.
			self newSeparator.
			self helpButton})
			vResizing: #spaceFill))
		layoutInset: 1