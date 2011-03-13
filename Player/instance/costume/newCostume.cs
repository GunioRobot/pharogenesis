newCostume

	| aMenu reply |
	aMenu := SelectionMenu selections: self availableCostumeNames.
	(reply := aMenu startUpWithCaption: 'choose a costume') ifNil: [^ self].
	self wearCostumeOfName: reply.
	self updateAllViewers