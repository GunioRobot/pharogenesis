initialize

	^ self initializeForWeek: Date today asWeek
		month: Date today asMonth
		tileRect: (0@0 extent: 23@19)
		model: nil