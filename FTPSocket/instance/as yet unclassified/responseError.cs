responseError
	"If data is waiting, Check it to catch any error reports.  Keep all responses in a queue for caller to examine later."

	| all what |
	self dataAvailable ifTrue: [
		all _ self getResponseUpTo: CrLf.
		readAhead ifNil: [readAhead _ OrderedCollection new].
		readAhead addLast: (all at: 1).	"150 Opening binary mode data conn"
		readAhead addAll: ((all at: 3) findBetweenSubStrs: (Array with: CrLf)).
		readAhead do: [:resp |
			((resp at: 1) == $5) | ((resp at: 1) == $4) ifTrue: [
				what _ (PopUpMenu labels: 'OK\ debug ' withCRs) 
					startUpWithCaption: 'Server reported this error:\' withCRs, resp.
				what = 2 ifTrue: [self halt].
				self sendCommand: 'QUIT'.
				readAhead _ nil.	"clear queue"
				self responseOK.		"221"
				self destroy.
				^ true]]].

	^ false	"all OK so far"