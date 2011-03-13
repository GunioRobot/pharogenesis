addMorphicSwitchesTo: window at: aLayoutFrame

	window 
		addMorph: (self buildMorphicSwitches borderWidth: 0)
		fullFrame: aLayoutFrame.

