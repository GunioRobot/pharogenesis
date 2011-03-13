forceChangesToDisk
	"Ensure that the changes file has been fully written to disk by closing and re-opening it. This makes the system more robust in the face of a power failure or hard-reboot."

	| changesFile |
	changesFile _ SourceFiles at: 2.
	(changesFile isKindOf: FileStream) ifTrue: [
		changesFile flush.
		changesFile close.
		changesFile open: changesFile name forWrite: true.
		changesFile setToEnd.
	].
