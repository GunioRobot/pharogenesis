spyOn: aBlock    "MessageTally spyOn: [100 timesRepeat: [3.14159 printString]]"
	| node result |
	node _ self new.
	result _ node spyEvery: self defaultPollPeriod on: aBlock.
	(StringHolder new contents: (String streamContents: [:s | node report: s; close]))
		openLabel: 'Spy Results'.
	^ result