rightType: headerWord
	"Computer the correct header type for an object based on the size and compact class fields of the given base header word, rather than its type bits. This is used during marking, when the header type bits are used to record the state of tracing."

	(headerWord bitAnd: 16rFC) = 0  "zero size field in header word"
		ifTrue: [ ^ HeaderTypeSizeAndClass ]
		ifFalse: [
			(headerWord bitAnd: 16r1F000) = 0  "zero compact class field  in header word"
				ifTrue: [ ^ HeaderTypeClass ]
				ifFalse: [ ^ HeaderTypeShort ]].