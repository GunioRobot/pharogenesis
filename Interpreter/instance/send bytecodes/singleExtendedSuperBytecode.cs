singleExtendedSuperBytecode
	"Can use any of the first 32 literals for the selector and pass up to 7 arguments."

	| descriptor |
	descriptor _ self fetchByte.
	messageSelector _ self literal: (descriptor bitAnd: 16r1F).
	argumentCount _ descriptor >> 5.
	self superclassSend.
