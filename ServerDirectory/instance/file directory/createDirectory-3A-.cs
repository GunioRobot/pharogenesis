createDirectory: localName
	"Create a new sub directory within the current one"

	| so rr |
	type == #file ifTrue: [FileDirectory createDirectory: localName].

	so _ self openNoDataFTP.
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'MKD ', localName.
	(rr _ so responseOK) == true ifFalse: [socket _ nil.  ^ rr].	""
	socket ifNil: [
		so sendCommand: 'QUIT'.
		(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
		so destroy].	"Always OK to destroy"
