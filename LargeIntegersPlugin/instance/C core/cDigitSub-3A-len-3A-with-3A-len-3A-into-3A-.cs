cDigitSub: pByteSmall
		len: smallLen
		with: pByteLarge
		len: largeLen
		into: pByteRes
	| z limit |
	self var: #pByteSmall declareC: 'unsigned char * pByteSmall'.
	self var: #pByteLarge declareC: 'unsigned char * pByteLarge'.
	self var: #pByteRes declareC: 'unsigned char * pByteRes'.
	self var: #smallLen declareC: 'int smallLen'.
	self var: #largeLen declareC: 'int largeLen'.

	z _ 0.
	"Loop invariant is -1<=z<=1"
	limit _ smallLen - 1.
	0 to: limit do: 
		[:i | 
		z _ z + (pByteLarge at: i) - (pByteSmall at: i).
		pByteRes at: i put: z - (z // 256 * 256).
		"sign-tolerant form of (z bitAnd: 255)"
		z _ z // 256].
	limit _ largeLen - 1.
	smallLen to: limit do: 
		[:i | 
		z _ z + (pByteLarge at: i) .
		pByteRes at: i put: z - (z // 256 * 256).
		"sign-tolerant form of (z bitAnd: 255)"
		z _ z // 256].
