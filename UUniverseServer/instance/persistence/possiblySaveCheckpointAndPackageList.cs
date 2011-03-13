possiblySaveCheckpointAndPackageList
	saveDirectory ifNil: [^self].
	(lastSaveTime isNil 
		or: [DateAndTime now - lastSaveTime > (Duration minutes: 30)]) 
			ifTrue: 
				[self saveCheckpoint.
				self savePackageList.
				lastSaveTime := DateAndTime now]