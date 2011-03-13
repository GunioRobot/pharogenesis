initializeTocLists
	tocLists _ Array new: 6.
	1
		to: tocLists size
		do: [:index | tocLists at: index put: OrderedCollection new]