linkAndSendSelector: sel to: rcvr nArgs: nArgs type: type
	"The name says it all.
	sel is a Symbol; type is 0 for short sends, 1 for extended, 2 for double-extended."

	| prevClass tMeth primIdx ip rcvrClass |
	self inline: false.

	messageSelector _ sel.
	argumentCount _ nArgs.
	newReceiver _ rcvr.
	rcvrClass _ self fetchClassOf: rcvr.
	self pushRemappableOop: rcvrClass.
	self findNewMethodInClass: rcvrClass.
	prevClass _ self popRemappableOop.
	messageSelector ~= (self splObj: SelectorDoesNotUnderstand) ifTrue: [
		tMeth _ newTranslatedMethod.
		"Note: tMeth might have come out of the method cache, so we can't assume it's young."
		self assertIsTranslatedMethod: tMeth.
		(self canLinkTo: tMeth) ifTrue: [
			(pseudoReceiver = 0) ifFalse: [prevClass _ self stableClassOf: newReceiver].
			ip _ self instructionPointer.		"ip might change during lookup"
			self linkSendOpcode: ip type: type receiver: newReceiver class: prevClass method: tMeth.
			primIdx _ self integerObjectOf: primitiveIndex.
			"this next store is probably redundant"
			self storePointer: MethodClassIndex ofObject: tMeth withValue: prevClass.
			self storeWord: MethodPrimIndex ofObject: tMeth withValue: primIdx]].
	self executeNewMethod