testPrintString

	"(self new setTestSelector: #testPrintString) debug"

	| dt |
	dt _DateAndTime
		year: 2004
		month: 11
		day: 2
		hour: 14
		minute: 3
		second: 5
		nanoSecond: 12345
		offset: (Duration seconds: (5 * 3600)).
	self assert: dt printString = '2004-11-02T14:03:05.000012345+05:00'


