printOn: aStream 
	| selector class mclass |
	self method == nil ifTrue: [^ super printOn: aStream].
	selector _ 
		(class _ self receiver class) 
			selectorAtMethod: self method 
			setClass: [:c | mclass _ c].
	selector == #?
		ifTrue: 
			[aStream nextPut: $?; print: self method who.
			^self].
	aStream nextPutAll: class name.
	mclass == class 
		ifFalse: 
			[aStream nextPut: $(.
			aStream nextPutAll: mclass name.
			aStream nextPut: $)].
	aStream nextPutAll: '>>'.
	aStream nextPutAll: selector.
	selector = #doesNotUnderstand: ifTrue: [
		aStream space.
		(self tempAt: 1) selector printOn: aStream.
	].
