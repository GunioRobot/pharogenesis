braceArray: anArray
	"This method is used in compilation of brace constructs.
	It MUST NOT be deleted or altered."

	collection _ anArray.
	position _ 0.
	readLimit _ 0.
	writeLimit _ anArray size.