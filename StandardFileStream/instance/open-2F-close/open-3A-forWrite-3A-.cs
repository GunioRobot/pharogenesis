open: fileName forWrite: writeMode 
	"Open the file with the given name. If writeMode is true, allow writing, otherwise open the file in read-only mode."
	"Changed to do a GC and retry before failing ar 3/21/98 17:25"
	| f |
	f _ fileName asVmPathName.

	fileID _ StandardFileStream retryWithGC:[self primOpen: f writable: writeMode] 
					until:[:id| id notNil] 
					forFileNamed: fileName.
	fileID ifNil: [^ nil].  "allows sender to detect failure"
	self register.
	name _ fileName.
	rwmode _ writeMode.
	buffer1 _ String new: 1.
