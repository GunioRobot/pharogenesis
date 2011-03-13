testSuperclass
	"self run: #testSuperclass"

	| s |
	self assert: Dictionary superclass == Set.
	self assert: OrderedCollection superclass == SequenceableCollection.

	s := OrderedCollection new.
	s add: SequenceableCollection.
	s add: Collection.
	s add: Object.
	s add: ProtoObject.

	self assert: OrderedCollection allSuperclasses = s.

	
	