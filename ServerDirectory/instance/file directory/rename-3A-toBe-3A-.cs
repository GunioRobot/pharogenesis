rename: fullName toBe: newName
	"Rename a remote file.  fullName is just be a fileName, or can be directory path that includes name of the server.  newName is just a fileName"
	| file so rr |

	file _ self asServerFileNamed: fullName.
	file isTypeFile ifTrue: [
		(FileDirectory forFileName: (file fileNameRelativeTo: self)) 
			rename: file fileName toBe: newName
	].
	
	so _ file openNoDataFTP.
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'RNFR ', file fileName.
	(rr _ so responseOK) == true ifFalse: [socket _ nil.  ^ rr].	""
	so sendCommand: 'RNTO ', newName.
	(rr _ so responseOK) == true ifFalse: [socket _ nil.  ^ rr].	""
	socket ifNil: [
		so sendCommand: 'QUIT'.
		(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
		so destroy].	"Always OK to destroy"
