veryDeepFixupWith: deepCopier 
	"See if the dependents are being copied also.  If so, point at the new copies.  (The dependent has self as its model.)
	Dependents handled in class Object, when the model is not a Model, are fixed up in Object veryDeepCopy."

	| originalDependents refs newDependent |
	super veryDeepFixupWith: deepCopier.
	originalDependents _ dependents.
	originalDependents ifNil: [
		^self.
		].
	dependents _ nil.
	refs _ deepCopier references.
	originalDependents
		do: [:originalDependent | 
			newDependent _ refs
						at: originalDependent
						ifAbsent: [].
			newDependent
				ifNotNil: [self addDependent: newDependent]]