rehash		"MultiSymbol rehash"
	"Rebuild the hash table, reclaiming unreferenced MultiSymbols."

	MultiSymbolTable _ WeakSet withAll: self allInstances.
	NewMultiSymbols _ WeakSet new.
