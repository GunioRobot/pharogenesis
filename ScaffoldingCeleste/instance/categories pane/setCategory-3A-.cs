setCategory: newCategory 
	"Change the currently selected category."
	newCategory ifNil: [
		"ignore requests to unset the category"
		^self ].

	categoryFilter := CelesteCategoryFilter forCategory: newCategory.
	self filtersChanged.
	self changed: #category
