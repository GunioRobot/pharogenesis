quit
	"break the connection"

	| rr so |
	(so _ socket) ifNil: [^ self].	"already done"
	socket _ nil.
	so isValid ifFalse: [^ self].
	so sendCommand: 'QUIT'.
	(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
	so destroy.	"Always OK to destroy"
	Transcript cr; show: 'ftp closing: ', server.