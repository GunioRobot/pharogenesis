cannotReturn: resultObj
	| result errantContext rcvrClass |
	self inline: false.
	self assertStackPointerIsExternal.

	self pushRemappableOop: resultObj.
	errantContext _ self pseudoContextFor: activeCachedContext.
	self push: errantContext.
	result _ self popRemappableOop.
	self push: result.
	messageSelector _ self splObj: SelectorCannotReturn.
	argumentCount _ 1.
	newReceiver _ errantContext.
	rcvrClass _ self fetchClassOf: newReceiver.
	self sendSelectorToClass: rcvrClass.