editCategoryFilter
	mailDB ifNil: [ ^self ].
	self editFilterNamed: self category.