primitiveAsyncFileWriteResult: fHandle

	| f r |
	self var: #f declareC: 'AsyncFile *f'.
	self primitive: 'primitiveAsyncFileWriteResult' parameters:#(Oop).

	f _ self asyncFileValueOf: fHandle.
	r _ self cCode:' asyncFileWriteResult(f)'.
	^r asOop: SmallInteger