spyOn: aBlock toFileNamed: fileName 
	"Spy on the evaluation of aBlock. Write the data collected on a file
	named fileName."

	| file value node |
	node _ self new.
	value _ node spyEvery: self defaultPollPeriod on: aBlock.
	file _ FileStream newFileNamed: fileName.
	node report: file; close.
	file close.
	^value