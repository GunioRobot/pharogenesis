compileReferenceAccessorFor: varName
	self class compileUnlogged: ((self referenceAccessorSelectorFor: varName), '
	^ ', varName)
		classified: 'reference' notifying: nil