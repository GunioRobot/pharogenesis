sampleScheduleList

	^ {
	PDAEvent new key: 'home'; date: Date today; description: 'wake up'; time: (Time hour: 6 minute: 0 second: 0).
	PDAEvent new key: 'home'; date: Date today; description: 'go for a run'; time: (Time hour: 7 minute: 0 second: 0).
	PDAEvent new key: 'home'; date: Date today; description: 'take a shower'; time: (Time hour: 8 minute: 0 second: 0).
	PDAEvent new key: 'home'; date: (Date today addDays: 2); description: 'dinner out'; time: (Time hour: 18 minute: 0 second: 0).
	PDAEvent new key: 'work'; date: (Date today addDays: 1); description: 'conf call'; time: (Time hour: 10 minute: 0 second: 0).
	PDAEvent new key: 'work'; date: (Date today addDays: 2); description: 'Leave for Conference'; time: (Time hour: 8 minute: 0 second: 0).
	PDAEvent new key: 'work'; date: Date today; description: 'call Boss'; time: (Time hour: 15 minute: 0 second: 0).
	PDAEvent new key: 'work'; date: Date today; description: 'Call about 401k'; time: (Time hour: 10 minute: 0 second: 0).
	}