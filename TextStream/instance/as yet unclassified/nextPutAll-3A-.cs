nextPutAll: aCollection 
	"Optimized access to get around Text at:Put: overhead"
	| n |
	n _ aCollection size.
     position + n > writeLimit
       ifTrue:
        [self growTo: position + n + 10].
	collection 
		replaceFrom: position+1
		to: position + n
		with: aCollection
		startingAt: 1.
	position _ position + n