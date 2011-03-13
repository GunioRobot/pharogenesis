removeRequirements: oldRequiredSelectorsByClass thatAreNotIn: requiredSelectorsByClass
	| cache newRequirements |
	oldRequiredSelectorsByClass keysAndValuesDo: 
			[:class :requirements | 
			newRequirements := requiredSelectorsByClass at: class
						ifAbsent: 
							[#()].
			cache := class requiredSelectorsCache.
			requirements 
				do: [:sel | (newRequirements includes: sel) ifFalse: [cache removeRequirement: sel]]]