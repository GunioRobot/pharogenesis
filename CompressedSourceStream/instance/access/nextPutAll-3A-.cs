nextPutAll: str
	| n nInSeg |
	n _ str size.
	n <= (writeLimit - position) ifTrue:
		["All characters fit in buffer"
		collection replaceFrom: position + 1 to: position + n with: str.
		dirty _ true.
		position _ position + n.
		readLimit _ readLimit max: position.
		endOfFile _ endOfFile max: self position.
		^ str].

	"Write what fits in segment.  Then (after positioning) write what remains"
	nInSeg _ writeLimit - position.
	nInSeg = 0
		ifTrue: [self position: self position.
				self nextPutAll: str]
		ifFalse: [self nextPutAll: (str first: nInSeg).
				self position: self position.
				self nextPutAll: (str allButFirst: nInSeg)]
	
