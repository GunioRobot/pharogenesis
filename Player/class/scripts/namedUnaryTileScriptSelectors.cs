namedUnaryTileScriptSelectors
	"Answer a list of all the selectors of named unary tile scripts"

	| sel |
	scripts ifNil: [^ OrderedCollection new].
	^ scripts select: [:aScript | ((sel _ aScript selector) ~~ nil) and: [sel numArgs == 0]] 
		thenCollect: [:aScript | aScript selector]