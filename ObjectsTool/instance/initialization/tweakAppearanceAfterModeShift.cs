tweakAppearanceAfterModeShift
	"After the receiver has been put into a given mode, make an initial selection of category, if appropriate, and highlight the mode button."

	self buttonPane submorphs do:
		[:aButton | 
			aButton borderWidth: 0.
			(aButton valueOfProperty: #modeSymbol) = modeSymbol
				ifTrue:
					[aButton firstSubmorph color: Color red]
				ifFalse:
					[aButton firstSubmorph color: Color black]].
