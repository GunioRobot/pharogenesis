spyOnProcess: aProcess forMilliseconds: msecDuration toFileNamed: fileName 
	"Spy on the evaluation of aProcess. Write the data collected on a file  
	named fileName. Will overwrite fileName"
	| file node |
	node _ self new.
	node
		spyEvery: self defaultPollPeriod
		onProcess: aProcess
		forMilliseconds: msecDuration.
	file _ FileStream fileNamed: fileName.
	node report: file;
		 close.
	file close