snapshotAndQuit
	"Snapshot and quit without bother the user further.  2/4/96 sw"

	SmalltalkImage current
		snapshot: true
		andQuit: true