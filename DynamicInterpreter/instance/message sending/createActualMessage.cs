createActualMessage

	| argumentArray message |
	self inline: false.

	argumentArray _ self instantiateClass: (self splObj: ClassArray) indexableSize: argumentCount.
	"remap argumentArray in case GC happens during allocation"
	self pushRemappableOop: argumentArray.
	message _ self instantiateClass: (self splObj: ClassMessage) indexableSize: 0.
	argumentArray _ self popRemappableOop.

	(argumentArray < youngStart) ifTrue: [ self beRootIfOld: argumentArray ].

	self storePointer: MessageSelectorIndex		ofObject: message withValue: messageSelector.
	self storePointer: MessageArgumentsIndex	ofObject: message withValue: argumentArray.

	self pop: argumentCount.
	self	transfer:	argumentCount
		wordsFrom:	self stackPointer + 4					"first argument"
		to:			argumentArray + BaseHeaderSize.	"first indexed field"
	self push: message.

	argumentCount _ 1.