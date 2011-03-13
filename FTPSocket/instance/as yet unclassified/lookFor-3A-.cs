lookFor: beginning
	"Get the response from the server.  If 1xx, in progress.  If 2xx, success.  If 3xx, intermediate point successful.  4xx, transient error.  5xx, true error.  If 4 or 5, put up dialog, kill the socket, and return the response string.  Return true the string in beginning is at the front of what came back.  Ignore any 2xx response that is not what we want, but print it."
	| resp what all |
	readAhead size > 0
		ifTrue: [resp _ readAhead removeFirst]	"response already came in"
		ifFalse: [
			all _ self getResponseUpTo: CrLf.
			resp _ all at: 1.	"150 Opening binary mode data conn"
			readAhead _ (all at: 3) findBetweenSubStrs: (Array with: CrLf)].
	Transcript show: resp; cr.
	resp size > 0 
		ifTrue: [
			(resp at: 4) == $- ifTrue: [^ self lookFor: beginning].	"is a comment"
			(resp beginsWith: beginning) ifTrue: [^ true].	"exactly what we wanted"
			"((resp at: 1) isDigit) & ((resp at: 1) digitValue < 4) ifTrue: [^ self lookFor: beginning]."
				"the way I used to detect comments"
			]
		ifFalse: [resp _ '[timeout]'].
	what _ (PopUpMenu labels: 'OK\ debug ' withCRs) 
		startUpWithCaption: 'Server reported this error:\' withCRs, resp.
	what = 2 ifTrue: [self halt].
	self destroy.
	^ resp