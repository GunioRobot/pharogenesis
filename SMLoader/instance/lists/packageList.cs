packageList
	"Return a list of the SMPackages that should be visible
	by applying all the filters. Also filter based on the currently
	selected category - if any."

	| list selectedCategory |
	list := packagesList ifNil: [
			packagesList := self packages select: [:p | 
				filters allSatisfy: [:currFilter |
					currFilter isSymbol
						ifTrue: [(self perform: currFilter) value: p]
						ifFalse: [
						self package: p
							filteredByCategory: (model object: currFilter)]]]].
	selectedCategoryWrapper ifNil:[self updateLabel: list. ^list].
	selectedCategory := selectedCategoryWrapper category.
	list := list select: [:each | self package: each filteredByCategory: selectedCategory].
	self updateLabel: list.
	^list