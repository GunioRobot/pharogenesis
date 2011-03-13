hintingFullPreferenceChanged
	Preferences HintingFull
		ifTrue:[Preferences disable: #HintingNone; disable: #HintingLight; disable: #HintingNormal]
		ifFalse:[
			(Preferences HintingNone or:[Preferences HintingLight or:[Preferences HintingNormal]])
				ifFalse:[
					"turn it back on again"
					^Preferences enable: #HintingFull]].
	monoHinting := Preferences HintingFull.
	lightHinting := Preferences HintingLight.
	hinting := monoHinting or:[lightHinting or:[Preferences HintingNormal]].
	FreeTypeCache current removeAll.
	FreeTypeFont allSubInstances do:[:each | each clearCachedMetrics].
	NewParagraph allSubInstances do:[:each | each composeAll].
	World restoreMorphicDisplay.

