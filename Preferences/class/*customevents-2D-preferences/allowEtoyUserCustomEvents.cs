allowEtoyUserCustomEvents
	^ (self valueOfFlag: #allowEtoyUserCustomEvents
		ifAbsent: [false]) and: [ self eToyFriendly not ]