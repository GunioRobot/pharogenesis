test04metaclassSuperclass


	| s |
	self assert: Dictionary class superclass == Set class.
	self assert: OrderedCollection class superclass == SequenceableCollection class.

	