save
	"Atomically save a representation of this object to its file. The old file is 
	renamed to '<oldname>.bak' before the new file is written. If the write 
	operation fails, the old file may be restored by renaming it. If it 
	succeeds, the .bak file is deleted."
	"create the file if it doesn't already exist"
	| f dir shortName |
	(StandardFileStream isAFileNamed: filename)
		ifFalse: 
			[f _ StandardFileStream new open: filename forWrite: true.
			f close].
	shortName _ FileDirectory localNameFor: filename.
	dir _ FileDirectory forFileName: filename.
	dir rename: shortName toBe: shortName , '.bak'.
	Cursor write showWhile: [f _ FileStream fileNamed: filename.
	self writeOn: f.
	f setToEnd; close.].
	dir deleteFileNamed: shortName , '.bak' ifAbsent: []