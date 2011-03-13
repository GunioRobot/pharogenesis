selectCategoryForClass: theClass
	"Set the package and category lists to display the given class."

	| cat |
	cat := theClass category.
	self packageListIndex: (self packageList indexOf: (cat copyUpTo: $-)).	
	self systemCategoryListIndex: (self systemCategoryList indexOf: 
			(cat copyFrom: ((cat indexOf: $- ifAbsent: [0]) + 1) to: cat size)).