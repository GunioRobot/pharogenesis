bringFlapTabsToFront
	self flapTabs do:
		[:m | self addMorphFront: m]