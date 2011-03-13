copyEmpty
	^super copyEmpty
		hashBlock: hashBlock copy;
		equalBlock: equalBlock copy