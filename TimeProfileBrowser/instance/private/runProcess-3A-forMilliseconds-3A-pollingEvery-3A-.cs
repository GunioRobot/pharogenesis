runProcess: aProcess forMilliseconds: msecDuration pollingEvery: pollPeriod 
	| stream list result |
	block := MessageSend 
				receiver: self
				selector: #runProcess:forMilliseconds:pollingEvery: 
				arguments: { 
						aProcess.
						msecDuration.
						pollPeriod}.	"so we can re-run it"
	tally := MessageTally new.
	tally
		reportOtherProcesses: false;
		maxClassNameSize: 1000;
		maxClassPlusSelectorSize: 1000;
		maxTabs: 100.
	result := tally 
				spyEvery: pollPeriod
				onProcess: aProcess
				forMilliseconds: msecDuration.
	stream := ReadWriteStream 
				with: (String streamContents: 
							[:s | 
							tally
								report: s;
								close]).
	stream reset.
	list := OrderedCollection new.
	[stream atEnd] whileFalse: [list add: stream nextLine].
	self initializeMessageList: list.
	self changed: #messageList.
	self changed: #messageListIndex.
	^result