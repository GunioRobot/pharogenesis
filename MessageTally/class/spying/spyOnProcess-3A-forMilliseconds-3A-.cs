spyOnProcess: aProcess forMilliseconds: msecDuration 
	"| p |  
	p _ [100000 timesRepeat: [3.14159 printString]] fork.  
	(Delay forMilliseconds: 100) wait.  
	MessageTally spyOnProcess: p forMilliseconds: 1000"
	| node |
	node _ self new.
	node
		spyEvery: self defaultPollPeriod
		onProcess: aProcess
		forMilliseconds: msecDuration.
	(StringHolder new
		contents: (String
				streamContents: [:s | node report: s;
						 close]))
		openLabel: 'Spy Results'