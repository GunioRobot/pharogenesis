error: reason
	| backtrace |
	backtrace _ '
VM panic: ' , reason , '
'", self dumpStack".
	InterpreterLog show: backtrace.
	InterpreterLog isTranscript ifFalse: [Transcript show: backtrace].
	super error: 'VM panic: ' , reason