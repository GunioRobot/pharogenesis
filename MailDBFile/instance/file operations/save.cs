save
	"Atomically save a representation of this object to its file.  The new file is written to <name>.new, and on success, renamed to simply <name>.  If the write fails, then the old version will still exist"

	| f dir shortName |

	(StandardFileStream fileNamed: filename) close.	"ensure it exists"
	shortName _ FileDirectory localNameFor: filename.
	dir _ FileDirectory forFileName: filename.

	Cursor write showWhile: [
		f _ FileStream fileNamed: filename, '.new'.
		self writeOn: f.
		f setToEnd; close
		].
	dir deleteFileNamed: shortName ifAbsent: [].
	dir rename: shortName, '.new' toBe: shortName.

	self updateSizeAndModTime.