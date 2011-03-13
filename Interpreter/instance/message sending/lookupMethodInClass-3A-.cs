lookupMethodInClass: class
	| currentClass dictionary found rclass |
	self inline: false.

	currentClass _ class.
	[currentClass ~= nilObj]
		whileTrue:
		[dictionary _ self fetchPointer: MessageDictionaryIndex ofObject: currentClass.
		dictionary = nilObj ifTrue:
			["MethodDict pointer is nil (hopefully due a swapped out stub)
				-- raise exception #cannotInterpret:."
			self pushRemappableOop: currentClass.  "may cause GC!"
			self createActualMessageTo: class.
			currentClass _ self popRemappableOop.
			messageSelector _ self splObj: SelectorCannotInterpret.
			^ self lookupMethodInClass: (self superclassOf: currentClass)].
		found _ self lookupMethodInDictionary: dictionary.
		found ifTrue: [^ methodClass _ currentClass].
		currentClass _ self superclassOf: currentClass].

	"Could not find #doesNotUnderstand: -- unrecoverable error."
	messageSelector = (self splObj: SelectorDoesNotUnderstand) ifTrue:
		[self error: 'Recursive not understood error encountered'].

	"Cound not find a normal message -- raise exception #doesNotUnderstand:"
	self pushRemappableOop: class.  "may cause GC!"
	self createActualMessageTo: class.
	rclass _ self popRemappableOop.
	messageSelector _ self splObj: SelectorDoesNotUnderstand.
	^ self lookupMethodInClass: rclass