at: key put: anObject 
	"Set the value at key to be anObject.  If key is not found, create a new
	entry for key and set is value to anObject. Answer anObject."
	| index element |
	key isNil ifTrue:[^anObject].
	index := self findElementOrNil: key.
	element := array at: index.
	element == nil
		ifTrue: [self atNewIndex: index put: (WeakKeyAssociation key: key value: anObject)]
		ifFalse: [element value: anObject].
	^ anObject