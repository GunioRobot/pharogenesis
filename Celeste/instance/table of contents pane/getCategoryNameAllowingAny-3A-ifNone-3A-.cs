getCategoryNameAllowingAny: allowingAny  ifNone: aBlock
	"Prompt the user for a category name.
		allowingAny - whether any category should be allowed, including things like .all.
		aBlock - evaluated and returned if the user refuses to make a selection"

	| categoryName categoryMenu disallowedCategories |
	disallowedCategories _ allowingAny ifTrue: [{}] ifFalse: [{'.all.' . '.trash.' . '.unclassified.'}].
	categoryMenu _ CustomMenu selections: (mailDB allCategories copyWithoutAll: disallowedCategories), {'<new category>'}.
	categoryName _ categoryMenu startUp.
	categoryName = nil ifTrue: [^aBlock value].
	categoryName = '<new category>' ifTrue: [
		categoryName _ FillInTheBlank
			request: 'New category name?'
			initialAnswer: ''.
		(categoryName isEmpty) ifTrue: [^aBlock value].
		mailDB addCategory: categoryName.
		self changed: #categoryList.
	].
	self lastCategory: categoryName.
	^ categoryName