defaultCurrent
	^self new
		addFontProvider: FreeTypeFontProvider current;
		yourself