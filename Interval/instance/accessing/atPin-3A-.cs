atPin: anInteger 
	"Answer the anInteger'th element.  Return first or last if out of bounds.  6/18/96 tk"

anInteger >= 1
	ifTrue: [anInteger <= self size
		ifTrue: [^start + (step * (anInteger - 1))]
		ifFalse: [^ self last]]
	ifFalse: [^ self first]