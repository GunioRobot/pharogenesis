closed
	"Answer true if this file is closed."

	^ fileID isNil or: [(self primSizeNoError: fileID) isNil]
