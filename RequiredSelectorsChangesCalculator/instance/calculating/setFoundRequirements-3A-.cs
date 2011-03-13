setFoundRequirements: requiredSelectorsByClass 
	| cache |
	requiredSelectorsByClass keysAndValuesDo: 
			[:class :requirements | 
			cache := class requiredSelectorsCache.
			requirements do: [:sel | cache addRequirement: sel]].
	^cache