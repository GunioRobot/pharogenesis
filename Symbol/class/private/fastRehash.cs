fastRehash		"Symbol fastRehash"
	"Rebuild the hash table, reclaiming unreferenced Symbols"

	| oldSize |

	oldSize _ SymbolTable size.
	Smalltalk garbageCollect.
	self rehash.
	^(oldSize - SymbolTable size) printString, ' symbols reclaimed'