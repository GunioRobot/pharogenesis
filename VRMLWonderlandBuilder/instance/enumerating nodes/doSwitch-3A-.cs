doSwitch: node
	| choices which |
	choices _ (node attributeValueNamed:'choices').
	which _ (node attributeValueNamed: 'whichChoice') + 1.
	(which > 0 and:[which <= choices size])
		ifTrue:[(choices at: which) doWith: self].