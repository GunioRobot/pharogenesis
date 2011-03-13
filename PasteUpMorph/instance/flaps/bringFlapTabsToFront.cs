bringFlapTabsToFront
	(submorphs select:[:m| m isFlapOrTab]) do:[:m| self addMorphInLayer: m].