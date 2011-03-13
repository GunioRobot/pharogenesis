fallbackFont: aFontSetOrNil

	aFontSetOrNil == self
		ifTrue:[^ self error: 'Invalid fallback font'].

	fallbackFont _ aFontSetOrNil.
