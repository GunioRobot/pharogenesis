initialize
	BackupJobs := OrderedCollection new.
	self addToBackupJob: [Smalltalk garbageCollect].

	ActionTable := Dictionary new.


