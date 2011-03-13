sourceMap
	"Answer a SortedCollection of associations of the form: pc (byte offset in 
	me) -> sourceRange (an Interval) in source text."

	self generate: #(0 0 0 ).
	^encoder sourceMap