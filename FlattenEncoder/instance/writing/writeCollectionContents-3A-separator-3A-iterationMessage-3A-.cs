writeCollectionContents:aCollection separator:separator iterationMessage:op
	| first |
	first _ true.
	aCollection perform:op with: [ :each |  first ifFalse:[ self writeObject:separator ]. self write:each. first_false.].
