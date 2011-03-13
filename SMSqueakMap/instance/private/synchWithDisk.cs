synchWithDisk
	"Synchronize myself with the checkpoints on disk.
	If there is a newer checkpoint than I know of, load it.
	If there is no checkpoint or if I have a higher checkpoint number,
	create a new checkpoint from me.

	The end result is that I am in synch with the disk and we are both as
	updated as possible."

	| checkpointNumberOnDisk |
	 "If there is no checkpoint, save one from me."
	(self isCheckpointAvailable) ifFalse: [^self createCheckpointNumber: checkpointNumber].
	"If the one on disk is newer, load it"
	checkpointNumberOnDisk := self lastCheckpointNumberOnDisk.
	(checkpointNumber < checkpointNumberOnDisk)
		ifTrue: [^self reload].
	"If I am newer, recreate me on disk"
	(checkpointNumberOnDisk < checkpointNumber)
		ifTrue: [^self createCheckpointNumber: checkpointNumber]