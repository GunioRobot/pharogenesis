storeRequirementsUnder: rc for: selector in: requiredSelectorsByClass 
	| requiringClasses selectorsForClass |
	requiringClasses := rc updateRequiredStatusFor: selector
				inSubclasses: (self possiblyAffectedForRoot: rc).
	^requiringClasses do: 
			[:requiringClass | 
			selectorsForClass := requiredSelectorsByClass at: requiringClass
						ifAbsentPut: [IdentitySet new].
			selectorsForClass add: selector]