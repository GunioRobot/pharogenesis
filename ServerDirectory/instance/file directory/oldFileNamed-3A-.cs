oldFileNamed: fullName
	"If the file exists, answer a read-only RemoteFileStream on it.  fullName is directory path, and does include name of the server.  Or it can just be a fileName.  For now, pre-read the file."

	| file remoteStrm |
	file _ self as: ServerFile.
	(fullName includes: self pathNameDelimiter)
		ifTrue: [file fullPath: fullName]		"sets server, directory(path), fileName"
		ifFalse: [file fileName: fullName].	"already have the rest"
	file readOnly.
	remoteStrm _ RemoteFileStream on: (String new: 2000).
	remoteStrm remoteFile: file.
	file getFileNamed: file fileName into: remoteStrm.
	^ remoteStrm