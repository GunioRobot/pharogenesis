printOn: aStream
	aStream
		nextPutAll: self class name;
		nextPut: $(;
		cr.
	kfList do:[:item| aStream print: item; cr].

	aStream nextPut:$).