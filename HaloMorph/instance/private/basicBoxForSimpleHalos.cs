basicBoxForSimpleHalos

	^ (target topRendererOrSelf worldBoundsForHalo expandBy: self handleAllowanceForIconicHalos)
			intersect: (self world bounds insetBy: 8@8)
