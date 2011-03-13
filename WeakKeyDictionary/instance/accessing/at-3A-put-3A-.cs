at: key put: anObject 
	"Set the value at key to be anObject.  If key is not found, create a new
	entry for key and set is value to anObject. Answer anObject."
	| index element |
	key ifNil: [^anObject].
	index := self findElementOrNil: key.
	element := array at: index.
	element
		ifNil: [self atNewIndex: index put: (WeakKeyAssociation key: key value: anObject)]
		ifNotNil: [element value: anObject].
	^ anObject