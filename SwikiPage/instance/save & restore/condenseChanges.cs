condenseChanges
	"Save only the most recent version of this page"

	| theFile recentChunk newFile |
	theFile _ FileStream oldFileNamed: file.
	theFile setToEnd.
	self backupAChunk: theFile.
	recentChunk _ theFile nextChunk.
	theFile close. 
	FileDirectory deleteFilePath: file.
	newFile _ FileStream newFileNamed: file.
	newFile nextChunkPut: recentChunk; cr; close.