synchronizeToDisk
	"synchronize the in-memory data structures with what is on disk; most likely a snapshot is about to be made"

	mailDB ifNotNil: [mailDB close].
	self account clearPasswords.		"slightly misplaced in a method of this name, but it should really happen before a snapshot"