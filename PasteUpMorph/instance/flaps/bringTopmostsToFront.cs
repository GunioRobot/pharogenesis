bringTopmostsToFront
	(submorphs select:[:m| m wantsToBeTopmost]) do:[:m| self addMorphInLayer: m].