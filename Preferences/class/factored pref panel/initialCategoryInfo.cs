initialCategoryInfo
	| categories |
	categories _ IdentityDictionary new.
	self allPreferenceInitializationSpecs do:
		[:spec |
			spec size > 2 ifTrue:
				[spec third do:
					[:sym | 
						(categories includesKey: sym) ifFalse:
							[categories at: sym put: OrderedCollection new].
					(categories at: sym) add: spec first]]].
	^ categories keys asSortedArray collect:
		[:aKey | Array with: aKey with: (categories at: aKey) asSortedArray]