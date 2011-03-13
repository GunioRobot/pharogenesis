testReadFromFoolProofExtension
	"Convenient extension without a time, only a date"
	"self debug: #testReadFromFoolProofExtension"
	
	self assert: ('2008' asDateAndTime printString = '2008-01-01T00:00:00+00:00').
	self assert: ('2008-08' asDateAndTime printString = '2008-08-01T00:00:00+00:00').
	self assert: ('2006-08-28' asDateAndTime printString = '2006-08-28T00:00:00+00:00').
	"Regular nanoseconds"
	self assert: ('2006-08-28T00:00:00.123456789' asDateAndTime printString = '2006-08-28T00:00:00.123456789+00:00').
	"Extra picoseconds precision should not spoil the DateAndTime"
	self assert: ('2006-08-28T00:00:00.123456789000' asDateAndTime printString = '2006-08-28T00:00:00.123456789+00:00').