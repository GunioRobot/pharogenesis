selectedMessageName
	"Answer the name of the currently selected message."

	| example tokens |
	selectorIndex = 0 ifTrue: [^nil].
	example _ selectorList at: selectorIndex.
	tokens _ Scanner new scanTokens: example.
	tokens size = 1 ifTrue: [^ tokens first].
	(tokens second includes: $:) ifTrue: [^ example findSelector].
	Symbol hasInterned: tokens second ifTrue: [:aSymbol | ^ aSymbol].
	^ nil