doit  "SystemTracer writeClone"
	"(StandardFileStream allInstances select:
		[:f | f name endsWith: 'clone.image']) do: [:f | f close]."
	| time1 time2 ctxt n |
	ctxt _ thisContext sender.
	ctxt push: nil.
	self init: ctxt.
	cleaningUp _ false.	"true means rewriting special objects in writeSpecial2"
	Transcript show: 'Tracing . . . '.
	time1 _ Time millisecondClockValue.
	file _ FileStream fileNamed: 'clone.image'.
	file binary.
	n _ self writeImage: (Array with: Smalltalk).
	time2 _ Time millisecondClockValue.
	Transcript cr; show: n printString , ' bytes written in '
			, (time2 - time1 //1000) printString , ' seconds.'.
	"ctxt pop" "So we can resume"