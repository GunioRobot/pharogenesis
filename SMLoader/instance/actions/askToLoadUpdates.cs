askToLoadUpdates
	"Check how old the map is and ask to update it
	if it is older than 10 days or if there is no map on disk."

	| available |
	available := model isCheckpointAvailable.
	(available not or: [
		(Date today subtractDate: (Date fromSeconds:
			(model directory directoryEntryFor: model lastCheckpointFilename)
				modificationTime)) > 3])
		ifTrue: [
			(self confirm: 
				(available ifTrue: ['The map on disk is more than 10 days old,
update it from the Internet?'] ifFalse: ['There is no map on disk,
fetch it from the Internet?']))
				ifTrue: [self loadUpdates]]