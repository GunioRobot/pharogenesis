printOn: aStream 
	"Refer to the comment in Object|printOn:."
 
	super printOn: aStream.
	aStream nextPutAll: ' with selector: ';
	 print: selector;
	 nextPutAll: ' and arguments: ';
	 print: args