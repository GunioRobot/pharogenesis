morphsUnknownToTheirOwners
	"Return a list of all morphs (other than HandMorphs) whose owners do not contain them in their submorph lists"
	"Morph morphsUnknownToTheirOwners"
	| problemMorphs itsOwner |
	problemMorphs _ OrderedCollection new.
	self allSubInstances do:
		[:m | (m isHandMorph not and: [((itsOwner _ m owner) ~~ nil and: [(itsOwner submorphs includes: m) not])])
			ifTrue:
				[problemMorphs add: m]].
	^ problemMorphs