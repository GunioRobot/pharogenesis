sharableLitIndex: literal
	"Special access prevents multiple entries for post-allocated super send special selectors"
	| p |
	p _ literalStream originalContents indexOf: literal.
	p = 0 ifFalse: [^ p-1].
	^ self litIndex: literal
