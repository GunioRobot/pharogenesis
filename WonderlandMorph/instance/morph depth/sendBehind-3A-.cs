sendBehind: aMorph
	"Put this morph behind the specified morph"

	((self owner) = (aMorph owner))
		ifFalse: [ myWonderland reportErrorToUser: 'The morphs need to have the same owner to put one behind the other.'.
				  ^ nil. ].

	(self owner) addMorph: self behind: aMorph.
