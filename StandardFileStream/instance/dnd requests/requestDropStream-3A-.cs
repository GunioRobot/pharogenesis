requestDropStream: dropIndex
	"Return a read-only stream for some file the user has just dropped onto Squeak."
	name := self primDropRequestFileName: dropIndex.
	fileID := self primDropRequestFileHandle: dropIndex.
	fileID == nil ifTrue:[^nil].
	self register.
	rwmode := false.
	buffer1 := String new: 1.

