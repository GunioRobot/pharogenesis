cDigitAdd: pByteShort len: shortLen with: pByteLong len: longLen into: pByteRes 
	"pByteRes len = longLen; returns over.."
	| accum limit |
	self returnTypeC: 'unsigned char'.
	self var: #pByteShort declareC: 'unsigned char * pByteShort'.
	self var: #pByteLong declareC: 'unsigned char * pByteLong'.
	self var: #pByteRes declareC: 'unsigned char * pByteRes'.
	self var: #shortLen declareC: 'int shortLen'.
	self var: #longLen declareC: 'int longLen'.
	self var: #accum declareC: 'int accum'.
	self var: #limit declareC: 'int limit'.
	accum _ 0.
	limit _ shortLen - 1.
	0 to: limit do: 
		[:i | 
		accum _ (accum bitShift: -8)
					+ (pByteShort at: i) + (pByteLong at: i).
		pByteRes at: i put: (accum bitAnd: 255)].
	limit _ longLen - 1.
	shortLen to: limit do: 
		[:i | 
		accum _ (accum bitShift: -8)
					+ (pByteLong at: i).
		pByteRes at: i put: (accum bitAnd: 255)].
	^ accum bitShift: -8