initBBOpTable
	opTable _ OpTable.
	maskTable _ Array new: 32.
	#(1 2 4 5 8 16 32) do:[:i| maskTable at: i put: (1 << i)-1].
	self initializeDitherTables.
	warpBitShiftTable _ CArrayAccessor on: (Array new: 32).