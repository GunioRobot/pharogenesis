fwdBlockValidate: addr
	"Raise an error if the given address is not a valid forward table entry."

	(( addr > endOfMemory) and:
	 [(addr <= fwdTableNext) and:
	 [(addr bitAnd: 3) = 0]])
		ifFalse: [ self error: 'invalid fwd table entry' ].