fieldsAsMimeHeader
	"return the entire header in proper MIME format"
	| strm |
	strm _ WriteStream on: (String new: 100).
	self fields associationsDo: [:e | strm nextPutAll: e key;
		 nextPutAll: ': ';
		 "circumvent the forced lowercasing of the subject MimeHeader"
		 nextPutAll: (e key = 'subject' ifTrue: [subject] ifFalse: [e value asHeaderValue]);
		 cr]. 
	^ strm contents