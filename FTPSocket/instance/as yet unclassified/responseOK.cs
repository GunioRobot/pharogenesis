responseOK
	"Get the response from the server.  If 1xx, in progress.  If 2xx,
success.  If 3xx, intermediate point successful.  4xx, transient error.
5xx, true error.  If 4 or 5, put up dialog and kill the socket.  Return
true if OK, the error string if not."

	| resp what all |
	readAhead isNil ifTrue: [readAhead _ ''].
	readAhead size > 0
		ifTrue: [resp _ readAhead removeFirst]	"response already
came in"
		ifFalse: [
			all _ self getResponseUpTo: CrLf.
			resp _ all at: 1.	"150 Opening binary mode
data conn"
			readAhead _ (all at: 3) findBetweenSubStrs: (Array
with: CrLf)].
	"Transcript show: resp; cr."
	resp size > 0
		ifTrue: [((resp at: 1) == $5) | ((resp at: 1) == $4)
ifFalse: [^ true]]  "All is well"
		ifFalse: [resp _ '[timeout]'].
	what _ (PopUpMenu labels: 'OK\ debug ' withCRs)
		startUpWithCaption: 'Server reported this error:\' withCRs,
resp.
	what = 2 ifTrue: [self halt].
	self destroy.
	^ resp