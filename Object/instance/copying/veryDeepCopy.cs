veryDeepCopy
	"Do a complete tree copy using a dictionary.  An object in the tree twice is only copied once.  Both pointers point to one new copy."

	| copier new refs newDep newModel |
	copier _ DeepCopier new initialize: self initialDeepCopierSize.
	new _ self veryDeepCopyWith: copier.
	copier mapUniClasses.
	copier references associationsDo: [:assoc | 
		assoc value veryDeepFixupWith: copier].
	"Fix dependents"
	refs _ copier references.
	DependentsFields associationsDo: [:pair |
		pair value do: [:dep | 
			(newDep _ refs at: dep ifAbsent: [nil]) ifNotNil: [
				newModel _ refs at: pair key ifAbsent: [pair key].
				newModel addDependent: newDep]]].
	^ new