primitivePerformWithArgs
	| performSelector argumentArray arraySize index cntxSize stackSize numArgs |
	self assertStackPointerIsExternal.
	argumentArray _ self popStack.
	arraySize _ self fetchWordLengthOf: argumentArray.
	cntxSize _ (self wordLengthOfContext: activeCachedContext) - TempFrameStart.		"max stack depth"
	stackSize _ (self stackPointer - (self cachedFramePointerAt: activeCachedContext)) // 4.	"current stack depth"
	self success: (cntxSize - stackSize) > arraySize.
	self successIfClassOf: argumentArray is: (self splObj: ClassArray).
	successFlag ifTrue: [
		performSelector _ messageSelector.
		messageSelector _ self popStack.
		newReceiver _ self stackTop.
		numArgs _ argumentCount _ arraySize.
		index _ 0.
		[index < numArgs] whileTrue: [
			self push: (self fetchPointer: index ofObject: argumentArray).
			index _ index + 1].
		self pushRemappableOop: performSelector.
		self pushRemappableOop: argumentArray.
"***		self lookupMethodInClass: (self fetchClassOf: newReceiver)."	"provokes GC!"
		self findNewMethodInClass: (self fetchClassOf: newReceiver).	"provokes GC!"
		argumentArray _ self popRemappableOop.
		performSelector _ self popRemappableOop.
		self success: (self argumentCountOf: newMethod) = argumentCount.
		successFlag ifTrue: [
			self executeNewMethod.  "Recursive xeq affects successFlag"
			successFlag _ true.
		] ifFalse: [
			self pop: argumentCount.
			self push: messageSelector.
			self push: argumentArray.
			argumentCount _ 2.
			messageSelector _ performSelector.
		].
	] ifFalse: [
		self unPop: 1.
	]