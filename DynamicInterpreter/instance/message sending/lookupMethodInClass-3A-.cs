lookupMethodInClass: class
	"Assumes: newReceiver contains the receiver with the given class"

	| currentClass dictionary found stableClass cls |
	currentClass _ class.
	[currentClass ~= nilObj] whileTrue: [
		dictionary _ self fetchPointer: MessageDictionaryIndex ofObject: currentClass.
		found _ self lookupMethodInDictionary: dictionary.
		found ifTrue: [^currentClass].
		currentClass _ self superclassOf: currentClass.
	].
	class = (self splObj: ClassPseudoContext) ifTrue: [
		self assertIsPseudoContext: newReceiver.
		pseudoReceiver _ newReceiver.		"changes behaviour of {activate,execute}NewMethod"
		stableClass _ self stableClassOf: newReceiver.
		self assertIsStableContextClass: stableClass.
		self lookupMethodInClass: stableClass.
		^nilObj.		"stableClass might be hit by a GC in the recursive call"
	].
	messageSelector = (self splObj: SelectorDoesNotUnderstand) ifTrue: [
		self error: 'Recursive not understood error encountered'
	].
	self pushRemappableOop: class.
	self createActualMessage.
	cls _ self popRemappableOop.
	messageSelector _ self splObj: SelectorDoesNotUnderstand.
	^self lookupMethodInClass: cls