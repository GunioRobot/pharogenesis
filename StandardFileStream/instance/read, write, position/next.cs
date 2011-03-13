next
	"Read the next object from the file. 2/12/96 sw"
	self primRead: fileID into: buffer1 startingAt: 1 count: 1.
	^ buffer1 at: 1