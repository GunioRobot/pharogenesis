encodePostscriptOn: aStream 
	self unhibernate.
	^ self printPostscript: aStream operator: (self depth = 1
			ifTrue: ['imagemask']
			ifFalse: ['image'])