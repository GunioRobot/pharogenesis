createActualMessage

	| argumentArray message |
	argumentArray _
		self instantiateClass: (self splObj: ClassArray) indexableSize: argumentCount.

	"remap argumentArray in case GC happens during allocation"
	self pushRemappableOop: argumentArray.
	message _ self instantiateClass: (self splObj: ClassMessage) indexableSize: 0.
	argumentArray _ self popRemappableOop.

	(argumentArray < youngStart) ifTrue: [ self beRootIfOld: argumentArray ].
	self storePointer: MessageSelectorIndex
		ofObject: message
		withValue: messageSelector.
	self storePointer: MessageArgumentsIndex
		ofObject: message
		withValue: argumentArray.
	self transfer: argumentCount
		fromIndex: self stackPointerIndex - (argumentCount - 1)
		ofObject: activeContext
		toIndex: 0
		ofObject: argumentArray.

	self pop: argumentCount.
	self push: message.
	argumentCount _ 1.