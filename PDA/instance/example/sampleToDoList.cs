sampleToDoList

	^ {
	PDAToDoItem new key: 'work'; dayPosted: (Date today subtractDays: 3); description: 'release external updates'; priority: 2.
	PDAToDoItem new key: 'work'; dayPosted: (Date today subtractDays: 3); description: 'first pass of sMovie'; priority: 1.
	PDAToDoItem new key: 'work'; dayPosted: (Date today subtractDays: 2); description: 'first pass of PDA'; priority: 2.
	PDAToDoItem new key: 'work'; dayPosted: (Date today subtractDays: 2); description: 'changes for finite undo'; priority: 2.
	PDAToDoItem new key: 'work'; dayPosted: (Date today subtractDays: 1); description: 'Msg to Freeman Zork'; priority: 1.
	PDAToDoItem new key: 'home'; dayPosted: (Date today subtractDays: 1); description: 'Fix fridge'; priority: 1.
	PDAToDoItem new key: 'home'; dayPosted: (Date today subtractDays: 3); description: 'Fix roof'; priority: 3.
	PDAToDoItem new key: 'home'; dayPosted: (Date today subtractDays: 3); description: 'Call about driveway'; priority: 4.
	}