initialize
	"DeflateStream initialize"
	#(	WindowSize WindowMask 
		MaxDistance MinMatch MaxMatch
		HashBits HashMask HashShift
	) do:[:sym|
			ZipConstants declare: sym from: Undeclared.
		].

	WindowSize _ 16r8000.
	WindowMask _ WindowSize - 1.
	MaxDistance _ WindowSize.

	MinMatch _ 3.
	MaxMatch _ 258.

	HashBits _ 15.
	HashMask _ (1 << HashBits) - 1.
	HashShift _ (HashBits + MinMatch - 1) // MinMatch.
