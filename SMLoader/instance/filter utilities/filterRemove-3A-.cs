filterRemove: anObject

	self changeFilters: (self filters copyWithout: anObject)
