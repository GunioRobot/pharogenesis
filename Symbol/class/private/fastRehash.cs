fastRehash		"Symbol fastRehash"
	"Rebuild the hash table, reclaiming unreferenced Symbols.
	Note: This requires the symbols to be held in weak arrays."
	| count oldCount |
	oldCount _ Symbol instanceCount.
	"Since we've got all the symbols in weak arrays do a big GC"
	Smalltalk garbageCollect.
	"And get rid of any nil entries"
	SelectorTables _ SelectorTables collect:[:table| 
			table collect:[:subTable| subTable copyWithout: nil]].
	OtherTable _ OtherTable collect:[:table| table copyWithout: nil].
	count _ Symbol instanceCount.
	^(oldCount - count) printString , ' reclaimed'