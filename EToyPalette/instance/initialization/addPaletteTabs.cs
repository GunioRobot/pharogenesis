addPaletteTabs
	#( (labelForPaintPalette showPaintPalette)
		(labelForControlsPalette	showControlsPalette)
		 (labelForSuppliesPalette	showSuppliesPalette)
				(labelForStuffPalette		showStuffPalette))  do: [:pair|
				self addButtonNamed: ((self perform: pair first), ' ') selector: pair second]