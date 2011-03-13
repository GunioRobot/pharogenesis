classCategoryNode
	^ OBClassCategoryNode 
		on: self theNonMetaClass category
		inEnvironment: self theClass environment