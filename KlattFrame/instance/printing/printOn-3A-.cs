printOn: aStream
	self class parameterNames do: [ :each |
		aStream
			nextPutAll: each;
			nextPut: $=; 
			print: (self perform: each);
			space]