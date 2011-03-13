compileReferenceAccessorFor: varName
	"Compile reference accessors for the given variable.  If the #capitalizedReferences preference is true, then nothing is done here"

	Preferences capitalizedReferences ifTrue: [^ self].

	self class compileUnlogged: ((self referenceAccessorSelectorFor: varName), '
	^ ', varName)
		classified: 'reference' notifying: nil