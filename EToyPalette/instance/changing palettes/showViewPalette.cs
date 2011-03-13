showViewPalette
	viewPalette ifNotNil:
		[self highlightPaletteName: 'View'.
		self showPalette: viewPalette]
