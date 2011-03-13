newColorPickerFor: target getter: getterSymbol setter: setterSymbol
	"Answer a new color picker for the given morph and accessors."

	^self theme
		newColorPickerIn: self
		for: target
		getter: getterSymbol
		setter: setterSymbol