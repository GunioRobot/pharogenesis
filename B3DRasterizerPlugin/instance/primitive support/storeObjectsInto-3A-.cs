storeObjectsInto: stackIndex
	| arrayOop arraySize objOop |
	arrayOop _ interpreterProxy stackObjectValue: stackIndex.
	arraySize _ self cCode: 'state.nObjects'.
	0 to: arraySize-1 do:[:i|
		objOop _ self cCode:'state.objects[i]->__oop__'.
		interpreterProxy storePointer: i ofObject: arrayOop withValue: objOop.
	].