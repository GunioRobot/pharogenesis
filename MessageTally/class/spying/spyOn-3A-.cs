spyOn: aBlock    "MessageTally spyOn: [100 timesRepeat: [3.14159 printString]]"
	| node |
	node _ self new.
	node spyEvery: 16 on: aBlock.
	(StringHolder new contents: (String streamContents: [:s | node report: s; close]))
		openLabel: 'Spy Results'