reversed
	"Answer a copy of the receiver with element order reversed.  1/26/96 sw"
	| newCol |
	newCol _ self species new.
	self reverseDo:
		[:elem | newCol add: elem].
	^ newCol


"#(2 3 4 'fred') reversed"