packageList
	| result |
	result _ versions
		inject: Set new
		into: [ :set :each | set add: each first; yourself ].

	"sort loaded packages first, then alphabetically"
	^result asSortedCollection: [:a :b |
		| loadedA loadedB |
		loadedA _ loaded anySatisfy: [:each | (each copyUpToLast: $-) = a].
		loadedB _ loaded anySatisfy: [:each | (each copyUpToLast: $-) = b].
		loadedA = loadedB 
			ifTrue: [a < b]
			ifFalse: [loadedA]]

