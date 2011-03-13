compileReferenceAccessorFor: varName
	self class compile: ((self referenceAccessorSelectorFor: varName), '
	^ ', varName)
		classified: 'reference' notifying: nil