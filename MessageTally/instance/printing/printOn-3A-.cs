printOn: aStream 
	| aSelector className aClass |
	(class isNil or: [method isNil]) ifTrue: [^super printOn: aStream].
	aSelector := class selectorAtMethod: method setClass: [:c | aClass := c].
	className := aClass name contractTo: self maxClassNameSize.
	aStream
		nextPutAll: className;
		nextPutAll: ' >> ';
		nextPutAll: (aSelector 
					contractTo: self maxClassPlusSelectorSize - className size)