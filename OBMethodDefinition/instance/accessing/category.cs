category
	^ category ifNil: [category := self theClass whichCategoryIncludesSelector: self selector]