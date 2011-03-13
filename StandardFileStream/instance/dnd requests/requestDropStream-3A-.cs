requestDropStream: dropIndex
	"Return a read-only stream for some file the user has just dropped onto Squeak."
	name _ self primDropRequestFileName: dropIndex.
	fileID _ self primDropRequestFileHandle: dropIndex.
	fileID == nil ifTrue:[^nil].
	self register.
	rwmode _ false.
	buffer1 _ String new: 1.

