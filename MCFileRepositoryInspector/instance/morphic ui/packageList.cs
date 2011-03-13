packageList
	| result |
	result := versions
		inject: Set new
		into: [ :set :each | set add: each first; yourself ].

	"sort loaded packages first, then alphabetically"
	result := result asSortedCollection: [:a :b |
		| loadedA loadedB |
		loadedA := loaded anySatisfy: [:each | (each copyUpToLast: $-) = a].
		loadedB := loaded anySatisfy: [:each | (each copyUpToLast: $-) = b].
		loadedA = loadedB 
			ifTrue: [a < b]
			ifFalse: [loadedA]].

	^result collect: [:each | self packageHighlight: each]