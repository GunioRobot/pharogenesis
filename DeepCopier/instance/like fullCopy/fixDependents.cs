fixDependents
	"They are not used much, but need to be right"

	| newDep newModel |
	DependentsFields associationsDo: [:pair |
		pair value do: [:dep | 
			newDep _ references at: dep ifAbsent: [nil].
			newDep ifNotNil: [
				newModel _ references at: pair key ifAbsent: [pair key].
				newModel addDependent: newDep]]].
