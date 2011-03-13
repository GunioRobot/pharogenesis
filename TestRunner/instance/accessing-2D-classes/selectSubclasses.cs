selectSubclasses
	| classesForPackages |
	classesForPackages := self findClassesForCategories: categoriesSelected.	
	classesSelected := (classesSelected gather: [ :class |
		class withAllSubclasses select: [ :each |
			classesForPackages includes: each ] ])
		asSet.
	self changed: #classSelected; changed: #hasRunnable.