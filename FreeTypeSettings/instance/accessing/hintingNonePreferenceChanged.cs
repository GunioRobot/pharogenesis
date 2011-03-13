hintingNonePreferenceChanged
	Preferences HintingNone
		ifTrue:[Preferences disable: #HintingFull; disable: #HintingLight; disable: #HintingNormal]
		ifFalse:[
			(Preferences HintingFull or:[Preferences HintingLight or:[Preferences HintingNormal]])
				ifFalse:[
					"turn it back on again"
					^Preferences enable: #HintingNone]].
	monoHinting := Preferences HintingFull.
	lightHinting := Preferences HintingLight.
	hinting := monoHinting or:[lightHinting or:[Preferences HintingNormal]].
	FreeTypeCache current removeAll.
	FreeTypeFont allSubInstances do:[:each | each clearCachedMetrics].
	NewParagraph allSubInstances do:[:each | each composeAll].
	World restoreMorphicDisplay.