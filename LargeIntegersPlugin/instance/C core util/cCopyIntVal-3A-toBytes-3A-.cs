cCopyIntVal: val toBytes: bytes 
	| pByte |
	self var: #pByte declareC: 'unsigned char *  pByte'.
	pByte _ interpreterProxy firstIndexableField: bytes.
	1 to: (self cDigitLengthOfCSI: val)
		do: [:ix | pByte at: ix - 1 put: (self cDigitOfCSI: val at: ix)]