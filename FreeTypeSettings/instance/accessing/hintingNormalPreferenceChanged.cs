hintingNormalPreferenceChanged
	Preferences HintingNormal
		ifTrue:[Preferences disable: #HintingNone; disable: #HintingLight; disable: #HintingFull ]
		ifFalse:[
			(Preferences HintingNone or:[Preferences HintingLight or:[Preferences HintingFull]])
				ifFalse:[
					"turn it back on again"
					^Preferences enable: #HintingNormal]].
	monoHinting := Preferences HintingFull.
	lightHinting := Preferences HintingLight.
	hinting := monoHinting or:[lightHinting or:[Preferences HintingNormal]].
	FreeTypeCache current removeAll.
	FreeTypeFont allSubInstances do:[:each | each clearCachedMetrics].
	NewParagraph allSubInstances do:[:each | each composeAll].
	World restoreMorphicDisplay.

