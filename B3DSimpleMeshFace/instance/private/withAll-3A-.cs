withAll: aCollection
	1 to: self size do:[:i|
		self at: i put: (aCollection at: i).
	].