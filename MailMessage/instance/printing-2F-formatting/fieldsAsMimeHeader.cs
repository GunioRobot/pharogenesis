fieldsAsMimeHeader
	"return the entire header in proper MIME format"

	self halt.		"This no longer appears to be used and since, as a result of recent changes, it references an undeclared variable <subject>, I have commented out the code to clean up the inspection of undeclared vars"

"---
	| strm |
	strm _ WriteStream on: (String new: 100).
	self fields associationsDo: [:e | strm nextPutAll: e key;
		 nextPutAll: ': ';
		 nextPutAll: (e key = 'subject' ifTrue: [subject] ifFalse: [e value asHeaderValue]);
		 cr]. 
	^ strm contents
---"