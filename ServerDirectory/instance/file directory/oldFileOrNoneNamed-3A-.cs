oldFileOrNoneNamed: fullName
	"If the file exists, answer a read-only RemoteFileStream on it. If it doesn't, answer nil.  fullName is directory path, and does include name of the server.  Or just a simple fileName.  Do prefetch the data."

	| file remoteStrm |
Cursor wait showWhile: 
	[type ifNil: [type _ #ftp].
	file _ self as: ServerFile.
	(fullName includes: self pathNameDelimiter)
		ifTrue: [file fullPath: fullName]		"sets server, directory(path), fileName"
		ifFalse: [file fileName: fullName].	"JUST a single NAME, rest is here"
			"Mac files that include / in name, must encode it as %2F "
	file readOnly.
	file type == #file ifTrue: [
		^ FileStream oldFileOrNoneNamed: (file fileNameRelativeTo: self)].
	"file exists ifFalse: [^ nil]."		"on the server"
	remoteStrm _ RemoteFileStream on: (String new: 2000).
	remoteStrm remoteFile: file.
	file getFileNamed: file fileName into: remoteStrm].	"prefetch data"
	^ remoteStrm