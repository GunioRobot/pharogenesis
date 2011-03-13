extent: extent fromArray: anArray
	"Load this 2-D array up from a 1-D array.  X varies most quickly.  6/20/96 tk"

	extent x * extent y = anArray size ifFalse: [
		^ self error: 'dimensions don''t match'].
	width _ extent x.
	contents _ anArray.