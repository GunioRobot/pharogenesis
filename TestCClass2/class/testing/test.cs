test
	"TestCClass2 test"
	"(CCodeGenerator new initialize addClass: TestCClass2) codeString"

	| bm |
	bm _ self new initialize.
	Transcript show: 'atAllPut: '.
	Transcript show: (Time millisecondsToRun: [bm atAllPut]) printString; cr.
	Transcript show: 'incrementAll: '.
	Transcript show: (Time millisecondsToRun: [bm incrementAll]) printString; cr.
	Transcript show: 'nestedWhileLoop: '.
	Transcript show: (Time millisecondsToRun: [bm nestedWhileLoop]) printString; cr.
	Transcript show: 'sieve: '.
	Transcript show: (Time millisecondsToRun: [bm sieve]) printString; cr.
	Transcript show: 'sumAll: '.
	Transcript show: (Time millisecondsToRun: [bm sumAll]) printString; cr.
	Transcript show: 'sumFromTo: '.
	Transcript show: (Time millisecondsToRun: [bm sumFromTo]) printString; cr.