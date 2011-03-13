shutDown
	"Stop player process, for example before snapshotting."

	self stopPlayerProcess.
	ReverbState _ nil.
