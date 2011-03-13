scanStringStruct: textOrString 
	"The input is a string whose elements are identifiers and parenthesized
	 groups of identifiers.  Answer an array reflecting that structure, representing
	 each identifier by an uninterned string."

	self scan: (ReadStream on: textOrString asString).
	self scanStringStruct.
	^token

	"Scanner new scanStringStruct: 'a b (c d) (e f g)'"