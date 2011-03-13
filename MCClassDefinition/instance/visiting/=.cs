= aDefinition
	^((super = aDefinition)
		and: [superclassName = aDefinition superclassName]
		and: [self traitCompositionString = aDefinition traitCompositionString]
		and: [self classTraitCompositionString = aDefinition classTraitCompositionString])
		and: [category = aDefinition category]
		and: [type = aDefinition type]
		and: [variables = aDefinition variables]
		and: [comment = aDefinition comment]
		