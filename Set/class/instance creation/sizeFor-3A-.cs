sizeFor: nElements
	"Large enough size to hold nElements with some slop (see fullCheck)"
	nElements <= 0 ifTrue: [^ 1].
	^ nElements+1*4//3