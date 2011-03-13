subPixelRenderFonts
	^ self
		valueOfFlag: #subPixelRenderFonts
		ifAbsent: [true]