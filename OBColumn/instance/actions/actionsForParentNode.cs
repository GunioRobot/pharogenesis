actionsForParentNode
	^ self filter children gather: [:child | child actionsForParent: self parent].	