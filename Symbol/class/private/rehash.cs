rehash		"Symbol rehash"
	"Rebuild the hash table, reclaiming unreferenced Symbols."

	SymbolTable _ WeakSet withAll: self allInstances.
	NewSymbols _ WeakSet new.