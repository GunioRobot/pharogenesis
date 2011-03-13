category
	^ category ifNil: [(Smalltalk classOrTraitNamed: self baseTrait)
							ifNotNil: [:baseTrait | baseTrait category]
							ifNil: [self error: 'Can''t detect the category']]