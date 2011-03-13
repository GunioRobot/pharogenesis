at: anIndex count: anInteger

	SimpleCounters ifNil: [(SimpleCounters _ Array new: 10) atAllPut: 0].
	SimpleCounters at: anIndex put: (SimpleCounters at: anIndex) + anInteger.