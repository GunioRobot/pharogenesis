printOn: aStream 
	"Append to the argument, aStream, a sequence of characters  
	that identifies the receiver."
	aStream nextPutAll: self class name;
		 nextPutAll: ' size:';
		 nextPutAll: size asString;
		 nextPutAll: ', calls:';
		 nextPutAll: calls asString;
		 nextPutAll: ', hits:';
		 nextPutAll: hits asString;
		 nextPutAll: ', ratio:';
nextPutAll: 
	(hits / calls) asFloat asString