setCategory: newCategory 
	"Add a filter for the specified category.  The user can remove any other category filters if they desire.  (Perhaps this should open a new Celeste window with the new category?).  Also, this causes the displayed messages to be updated."
	newCategory ifNil: [ ^self ].
	self currentCategory = newCategory ifTrue: [ self filtersChanged. ^self ].
	self addFilter: (CelesteCategoryFilter forCategory: newCategory)