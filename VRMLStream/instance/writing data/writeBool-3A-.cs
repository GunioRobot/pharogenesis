writeBool: aBoolean
	self nextPutAll: (aBoolean ifTrue:['TRUE'] ifFalse:['FALSE']).
