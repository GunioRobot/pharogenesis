sendInFrontOf: aMorph
	"Put this morph in front of the specified morph"

	((self owner) = (aMorph owner))
		ifFalse: [ myWonderland reportErrorToUser: 'The morphs need to have the same owner to put one in front of the other.'.
				  ^ nil. ].

	(self owner) addMorph: self inFrontOf: aMorph.
