intervalString
	"Treat the time as a difference.  Give it in hours and minutes with two digits of accuracy."

	| hh mm ss |
	hh _ hours = 0 ifTrue: [''] ifFalse: [' ', hours printString, ' hours'].
	mm _ minutes = 0 ifTrue: [''] ifFalse: [' ', minutes printString, ' minutes'].
	ss _ seconds = 0 ifTrue: [''] ifFalse: [' ', seconds printString, ' seconds'].
	hh size > 0 ifTrue: [ss _ ''].
	^ hh, mm, ss
