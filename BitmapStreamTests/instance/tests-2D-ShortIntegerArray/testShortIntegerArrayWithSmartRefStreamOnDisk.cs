testShortIntegerArrayWithSmartRefStreamOnDisk
	array _ ShortIntegerArray new: 10.
	1 to: 10 do: [ :i | array at: i put: self randomShortInt ].
	self validateSmartRefStreamOnDisk
	