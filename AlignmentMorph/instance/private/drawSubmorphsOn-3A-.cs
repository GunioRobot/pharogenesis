drawSubmorphsOn: aCanvas
	((self hasProperty: #clipToOwnerWidth) and: [owner isWorldOrHandMorph not])
		ifFalse:
			[super drawSubmorphsOn: aCanvas]
		ifTrue:
			[aCanvas
				clipBy:
					(self bounds intersect: owner bounds)
				during:
					[:clippedCanvas | super drawSubmorphsOn: clippedCanvas]]