printOn: aStream 
	| className |
	(class isNil or: [method isNil]) ifTrue: [^super printOn: aStream].
	className := method methodClass name contractTo: self maxClassNameSize.
	aStream
		nextPutAll: className;
		nextPutAll: ' >> ';
		nextPutAll: (method selector contractTo: self maxClassPlusSelectorSize - className size)