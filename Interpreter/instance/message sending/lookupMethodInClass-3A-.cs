lookupMethodInClass: class
	| currentClass dictionary found rclass |
	currentClass _ class.
	[currentClass ~= nilObj]
		whileTrue:
		[dictionary _ self fetchPointer: MessageDictionaryIndex ofObject: currentClass.
		found _ self lookupMethodInDictionary: dictionary.
		found ifTrue: [^ currentClass].
		currentClass _ self superclassOf: currentClass].

	messageSelector = (self splObj: SelectorDoesNotUnderstand) ifTrue:
		[self error: 'Recursive not understood error encountered'].

	self pushRemappableOop: class.
	self createActualMessage.  "may cause GC!"
	rclass _ self popRemappableOop.
	messageSelector _ self splObj: SelectorDoesNotUnderstand.
	^ self lookupMethodInClass: rclass