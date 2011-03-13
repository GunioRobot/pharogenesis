asInfiniteForm
	"Convert me into a normal Form, but one that knows to repeat when used as a source.  Call after sending depth: d.  Lose information about the true abstract Colors I have, and only keep information for the current depth.  6/20/96 tk"

	depth == nil ifTrue: [^ self error: 'Must specify a depth'].
	^ InfiniteForm with: (self as: Form)