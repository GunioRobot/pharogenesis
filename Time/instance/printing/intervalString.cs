intervalString
	"Treat the time as a difference.  Give it in hours and minutes with two digits of accuracy."

	| hh mm ss |
	hh _ self hours = 0 ifTrue: [''] ifFalse: [' ', self hours printString, ' hours'].
	mm _ self minutes = 0 ifTrue: [''] ifFalse: [' ', self minutes printString, ' minutes'].
	ss _ self seconds = 0 ifTrue: [''] ifFalse: [' ', self seconds printString, ' seconds'].
	hh size > 0 ifTrue: [ss _ ''].
	^ hh, mm, ss