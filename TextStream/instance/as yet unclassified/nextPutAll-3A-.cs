nextPutAll: aCollection 
	"Optimized access to get around Text at:Put: overhead"
	| n |
	n _ aCollection size.
	((aCollection isMemberOf: String) not or: [position + n > writeLimit])
		ifTrue: [^ super nextPutAll: aCollection].
	collection string
		replaceFrom: position+1
		to: position + n
		with: aCollection
		startingAt: 1.
	position _ position + n