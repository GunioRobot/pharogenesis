initialize
	ErrorRecursion _ false.
	ContextStackKeystrokes _ Dictionary new
		at: $e put: #send;
		at: $t put: #doStep;
		at: $p put: #proceed;
		at: $r put: #restart;
		at: $f put: #fullStack;
		at: $w put: #where;
		yourself.

	"Debugger initialize"