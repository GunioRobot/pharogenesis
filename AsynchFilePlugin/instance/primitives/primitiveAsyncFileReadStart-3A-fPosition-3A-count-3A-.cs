primitiveAsyncFileReadStart: fHandle fPosition: fPosition count: count
	| f |
	self var: #f declareC: 'AsyncFile *f'.
	self primitive: 'primitiveAsyncFileReadStart' parameters: #(Oop SmallInteger SmallInteger).
	f _ self asyncFileValueOf: fHandle.
	self cCode: 'asyncFileReadStart(f, fPosition, count)'
