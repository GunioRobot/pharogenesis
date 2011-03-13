testMetaclassSuperclass
	"self run: #testMetaclassSuperclass"

	self assert: Dictionary class superclass == Set class.
	self assert: OrderedCollection class superclass == SequenceableCollection class.

	