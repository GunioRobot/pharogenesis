rehash		"Symbol rehash"
	"Rebuild the hash table, reclaiming unreferenced Symbols."
	^SelectorTables first first class == (Smalltalk at: #WeakArray ifAbsent:[nil])
		ifTrue:[self fastRehash]
		ifFalse:[self slowRehash].