categoryNamed: category andOppositeDo: aBlock
	^ aBlock value: (self categoryNamed: category) value: (self oppositeCategoryOf: category)