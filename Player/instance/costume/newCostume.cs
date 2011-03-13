newCostume

	| aMenu reply |
	aMenu _ SelectionMenu selections: self availableCostumeNames.
	(reply _ aMenu startUpWithCaption: 'choose a costume') ifNil: [^ self].
	self wearCostumeOfName: reply