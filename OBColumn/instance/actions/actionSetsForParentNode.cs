actionSetsForParentNode
	^ self filter children gather: [:child | child actionSetsForParent: self parent].	