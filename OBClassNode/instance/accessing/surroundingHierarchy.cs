surroundingHierarchy
	 ^ (self theClass withAllSuperclasses union: self theClass allSubclasses)
		asArray