deleteFileNamed: fullName
	"Detete a remote file.  fullName is directory path, and does include name of the server.  Or it can just be a fileName."
	| file so rr |
	file _ self as: ServerFile.
	(fullName includes: self pathNameDelimiter)
		ifTrue: [file fullPath: fullName]		"sets server, directory(path), fileName"
		ifFalse: [file fileName: fullName].	"JUST a single NAME, rest is here"
			"Mac files that include / in name, must encode it as %2F "
	file type == #file ifTrue: [
		^ (FileDirectory forFileName: (file fileNameRelativeTo: self)) 
			deleteFileNamed: file fileName].
	
	so _ file openNoDataFTP.
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'DELE ', file fileName.
	(rr _ so responseOK) == true ifFalse: [socket _ nil.  ^ rr].	""
	socket ifNil: [
		so sendCommand: 'QUIT'.
		(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
		so destroy].	"Always OK to destroy"
