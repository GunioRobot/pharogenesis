removeRequirements: oldRequiredSelectorsByClass thatAreNotIn: requiredSelectorsByClass ifIn: rootsHandledBySel
	| cache newRequirements unconfirmedRequirements roots affected |
	oldRequiredSelectorsByClass keysAndValuesDo: 
			[:class :oldRequirements | 
			newRequirements := requiredSelectorsByClass at: class
						ifAbsent: [#()].
			cache := class requiredSelectorsCache.
			unconfirmedRequirements := oldRequirements copyWithoutAll: newRequirements.
			unconfirmedRequirements do: [:sel | 
				roots := rootsHandledBySel at: sel ifAbsent: [#()].
				(roots anySatisfy: [:rc | 
					affected := possiblyAffectedPerRoot at: rc ifAbsent: #().
					(affected includes: class)]) ifTrue: [cache removeRequirement: sel]]]