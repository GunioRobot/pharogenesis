printOn: aStream 
	"append to aStream a sequence of characters that identifies 
	the receiver."
	aStream nextPutAll: '{';
		 nextPutAll: initialFrame asString;
		 nextPutAll: '}{';
		 nextPutAll: endFrame asString;
		 nextPutAll: '}';
		 nextPutAll: contents asString