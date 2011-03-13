size
	depth = 16 ifTrue: [^ 32768].
	depth = 32 ifTrue: [^ 256*256*256].	"really 24 bit"
	^ 0