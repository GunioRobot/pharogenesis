newFromStream: s
	"Only meant for my subclasses that are raw bits and word-like.  For quick unpack form the disk."
	| len |

	self isPointers | self isWords not ifTrue: [^ super newFromStream: s].
		"super may cause an error, but will not be called."

	s next = 16r80 ifTrue:
		["A compressed format.  Could copy what BitMap does, or use a 
		special sound compression format.  Callers normally compress their own way."
		^ self error: 'not implemented'].
	s skip: -1.
	len _ s nextInt32.
	^ s nextWordsInto: (self basicNew: len)