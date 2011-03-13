initialize

	^ self initializeForWeek: Date today week
		month: Date today month
		tileRect: (0@0 extent: 23@19)
		model: nil