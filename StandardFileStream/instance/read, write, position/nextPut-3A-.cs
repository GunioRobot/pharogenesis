nextPut: char
	"Put char on the receiver stream.  2/12/96 sw"
	buffer1 at: 1 put: char.
	self primWrite: fileID from: buffer1
		startingAt: 1 count: 1.
	^ char