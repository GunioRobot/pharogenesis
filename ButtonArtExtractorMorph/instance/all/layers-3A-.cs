layers: aCollectionOfForms

	layers _ aCollectionOfForms asArray.
	layers size > 0 ifTrue: [visibleLayer form: layers first].
	self updateSelection.
