clearRootsTable
	"Clear the root bits of the current roots, then empty the roots 
	table. "
	"Caution: This should only be done when the young object 
	space is empty."
	"reset the roots table (after this, all objects are old so there 
	are no roots)"
	| oop |
	1 to: rootTableCount do: [:i | 
			"clear root bits of current root table entries"
			oop _ rootTable at: i.
			self longAt: oop put: ((self longAt: oop) bitAnd: AllButRootBit).
			rootTable at: i put: 0].
	rootTableCount _ 0