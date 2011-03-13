sampleScheduleList

	^ {
	PDAEvent new key: 'home'; date: Date today; description: 'wake up'; time: (Time new hours: 6).
	PDAEvent new key: 'home'; date: Date today; description: 'go for a run'; time: (Time new hours: 7).
	PDAEvent new key: 'home'; date: Date today; description: 'take a shower'; time: (Time new hours: 8).
	PDAEvent new key: 'home'; date: (Date today addDays: 2); description: 'dinner out'; time: (Time new hours: 18).
	PDAEvent new key: 'work'; date: (Date today addDays: 1); description: 'conf call'; time: (Time new hours: 10).
	PDAEvent new key: 'work'; date: (Date today addDays: 2); description: 'Leave for Conference'; time: (Time new hours: 8).
	PDAEvent new key: 'work'; date: Date today; description: 'call Boss'; time: (Time new hours: 15).
	PDAEvent new key: 'work'; date: Date today; description: 'Call about 401k'; time: (Time new hours: 10).
	}