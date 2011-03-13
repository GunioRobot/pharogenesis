getSelectorRootFor: receiver fromMessageNode: aMessageNode for: obj ignoreSelectors: ignoreSelectors

	| val |
	root _ nil.
	self getSelectorFor: receiver fromMessageNode: aMessageNode for: obj ifFoundDo: [:sel | root _ sel] ignoreSelectors: ignoreSelectors.
	val _ root.
	root _ nil.
	^ val.
