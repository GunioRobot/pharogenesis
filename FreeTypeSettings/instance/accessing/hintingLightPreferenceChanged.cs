hintingLightPreferenceChanged
	Preferences HintingLight
		ifTrue:[Preferences disable: #HintingFull; disable: #HintingNone; disable: #HintingNormal]
		ifFalse:[
			(Preferences HintingFull or:[Preferences HintingNone or:[Preferences HintingNormal]])
				ifFalse:[
					"turn it back on again"
					^Preferences enable: #HintingLight]].
	monoHinting := Preferences HintingFull.
	lightHinting := Preferences HintingLight.
	hinting := monoHinting or:[lightHinting or:[Preferences HintingNormal]].
	FreeTypeCache current removeAll.
	FreeTypeFont allSubInstances do:[:each | each clearCachedMetrics].
	NewParagraph allSubInstances do:[:each | each composeAll].
	World restoreMorphicDisplay.
