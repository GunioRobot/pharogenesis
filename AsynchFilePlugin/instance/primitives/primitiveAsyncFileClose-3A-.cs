primitiveAsyncFileClose: fh 
	| f |
	self var: #f declareC: 'AsyncFile *f'.
	self primitive: 'primitiveAsyncFileClose' parameters: #(Oop ).
	f _ self asyncFileValueOf: fh.
	self asyncFileClose: f