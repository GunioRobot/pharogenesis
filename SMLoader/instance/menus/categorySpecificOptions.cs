categorySpecificOptions
	| choices |
	choices := OrderedCollection new.
	(categoriesToFilterIds includes: self selectedCategory id)
		ifTrue: [
			choices add: #('remove filter' #removeSelectedCategoryAsFilter 'Remove the filter for the selected category.')]
		ifFalse: [
			choices add: #('add as filter' #addSelectedCategoryAsFilter 'Add the selected category as a filter so that only packages in that category are shown.')].
	categoriesToFilterIds isEmpty ifFalse: [
		choices add: #('remove all category filters' #removeCategoryFilters 'Remove all category filters.')].
	^ choices