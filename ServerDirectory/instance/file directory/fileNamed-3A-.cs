fileNamed: fullName
	"Create a RemoteFileStream for writing.  If the file exists, do not complain.  fullName is directory path, and does include name of the server.  Or it can just be a fileName.  Only write the data upon close."

	| file remoteStrm |
	file _ self as: ServerFile.
	(fullName includes: self pathNameDelimiter)
		ifTrue: [file fullPath: fullName]		"sets server, directory(path), fileName"
		ifFalse: [file fileName: fullName].	"JUST a single NAME, rest is here"
			"Mac files that include / in name, must encode it as %2F "
	file readWrite.
	file type == #file ifTrue: [
		^ FileStream fileNamed: (file fileNameRelativeTo: self)].

	remoteStrm _ RemoteFileStream on: (String new: 2000).
	remoteStrm remoteFile: file.
	^ remoteStrm	"no actual writing till close"
