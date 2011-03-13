populateInitialList
	"Use #bigList here for a large four column list amd #smallList for a  
	short three column test."
	smallTest == nil ifTrue: [smallTest _ true].
	theList _ (smallTest
				ifTrue: [self smallList]
				ifFalse: [self bigList]) asOrderedCollection