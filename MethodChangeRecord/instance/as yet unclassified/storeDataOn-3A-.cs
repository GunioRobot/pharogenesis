storeDataOn: aDataStream
	| oldMethod |
	oldMethod _ currentMethod.
	currentMethod _ nil.
	super storeDataOn: aDataStream.
	currentMethod _ oldMethod.
