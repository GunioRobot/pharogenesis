testShortPointArrayWithSmartRefStreamOnDisk
	array _ ShortPointArray new: 10.
	1 to: 10 do: [ :i | array at: i put: self randomShortPoint ].
	self validateSmartRefStreamOnDisk
	