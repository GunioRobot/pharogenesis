categories
	^ self theClass organization categories
		collect: [:cat | OBMethodCategoryNode on: cat inClass: self theClass]
			