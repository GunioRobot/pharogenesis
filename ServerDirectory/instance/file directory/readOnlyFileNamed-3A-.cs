readOnlyFileNamed: aName
	"If the file exists, answer a read-only RemoteFileStream on it.  aName is directory path, and does include name of the server.  Or it can just be a fileName.  For now, pre-read the file."

	| rFile remoteStrm |
	rFile _ self as: ServerFile.
	(aName includes: self pathNameDelimiter)
		ifTrue: [rFile fullPath: aName]
			"sets server, directory(path), fileName.  If relative, merge with self."
		ifFalse: [rFile fileName: aName].	"JUST a single NAME, already have the rest"
			"Mac files that include / in name, must encode it as %2F "
	rFile readOnly.
	rFile type == #file ifTrue: [
		^ FileStream oldFileNamed: (rFile fileNameRelativeTo: self)].

	remoteStrm _ RemoteFileStream on: (String new: 2000).
	remoteStrm remoteFile: rFile.
	rFile getFileNamed: rFile fileName into: remoteStrm.
	^ remoteStrm