veryDeepCopyUsing: copier
	"Do a complete tree copy using a dictionary.  An object in the tree twice is only copied once.  All references to the object in the copy of the tree will point to the new copy.
	Same as veryDeepCopy except copier (with dictionary) is supplied.
	** do not delete this method, even if it has no callers **"

	| new refs newDep newModel |
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