hasAdditionsToViewerCategories
	^ self class selectors
		anySatisfy: [:each | each == #additionsToViewerCategories
				or: [(each beginsWith: 'additionsToViewerCategory')
						and: [(each at: 26 ifAbsent: []) ~= $:]]]