testWith: anObject
	"As a test of DataStream/ReferenceStream, write out anObject and read it back.
	11/19/92 jhm: Set the file type. More informative file name."
	"DataStream testWith: 'hi'"
	"ReferenceStream testWith: 'hi'"
	| file result |

	file _ FileStream fileNamed: (self name, ' test').
	file binary.
	(self on: file) nextPut: anObject; setType.
	file close.

	file _ FileStream fileNamed: (self name, ' test').
	file binary.
	result _ (self on: file) next.
	file close.
	^ result