printOn: aStream
	super printOn: aStream.
	aStream
		nextPut:$[;
		print: self depth;
		space.
	self visible 
		ifTrue:[aStream nextPutAll:'visible']
		ifFalse:[aStream nextPutAll:'invisible'].
	aStream
		nextPutAll:' id = ';
		print: self id;
		nextPut:$];
		cr.