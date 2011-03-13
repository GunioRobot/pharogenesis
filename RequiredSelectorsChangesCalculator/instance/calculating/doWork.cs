doWork
	| requiredSelectorsByClass oldRequiredSelectorsByClass classWithOldRequirementsRecorded rootsHandledBySel rootsHandled |
	requiredSelectorsByClass := IdentityDictionary new.
	oldRequiredSelectorsByClass := IdentityDictionary new.
	classWithOldRequirementsRecorded := IdentitySet new.
	rootsHandledBySel := IdentityDictionary new.
	originalSinsPerSelector keysAndValuesDo: 
			[:selector :sinners | 
			rootsHandled := rootsHandledBySel at: selector put: IdentitySet new.
			rootClasses do: 
					[:rc | 
					(self shouldProcess: rc forSinsIn: sinners) 
						ifTrue: 
							[rootsHandled add: rc.
							self 
								storeOldRequirementsUnder: rc
								into: oldRequiredSelectorsByClass
								ignoreSet: classWithOldRequirementsRecorded.
							self 
								storeRequirementsUnder: rc
								for: selector
								in: requiredSelectorsByClass]]].
	self 
		removeRequirements: oldRequiredSelectorsByClass
		thatAreNotIn: requiredSelectorsByClass
		ifIn: rootsHandledBySel.
	self setFoundRequirements: requiredSelectorsByClass