printOn: aStream
	aStream
		nextPut:$<;
		nextPutAll: self callingConventionString; nextPutAll:': ';
		print: argTypes first; space.
	self name == nil
		ifTrue:[aStream nextPutAll:'(*) ']
		ifFalse:[aStream print: self name asString; space].
	aStream nextPut:$(.
	2 to: argTypes size do:[:i|
		aStream print: (argTypes at: i).
		i < argTypes size ifTrue:[aStream space]].
	aStream nextPut:$).
	self module == nil ifFalse:[
		aStream space; nextPutAll:'module: '; print: self module asString.
	].
	aStream nextPut:$>