sortCategories
	| privateCategories publicCategories newCategories |

	privateCategories _ self categories select:
		[:one | (one findString: 'private' startingAt: 1 caseSensitive: false) = 1].
	publicCategories _ self categories copyWithoutAll: privateCategories.
	newCategories _ publicCategories asSortedCollection asOrderedCollection
		addAll: privateCategories asSortedCollection;
		asArray.
	self categories: newCategories