fieldsAsMimeHeader
	"return the entire header in proper MIME format"
	| strm |
	strm _ WriteStream on: (String new: 100).
	self fields associationsDo: [:e | strm nextPutAll: e key;
		 nextPutAll: ': ';
		 nextPutAll: e value asHeaderValue;
		 cr]. 
	^ strm contents