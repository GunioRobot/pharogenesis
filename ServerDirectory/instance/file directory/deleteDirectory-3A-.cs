deleteDirectory: localName
	"Delete the sub directory within the current one.  Call needs to ask user to confirm."

	| so rr |
	type == #file ifTrue: [FileDirectory deleteFileNamed: localName].
		"Is this the right command???"

	so _ self openNoDataFTP.
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'RMD ', localName.
	(rr _ so responseOK) == true ifFalse: [socket _ nil.  ^ rr].	""
	socket ifNil: [
		so sendCommand: 'QUIT'.
		(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
		so destroy].	"Always OK to destroy"
