applyUpdatesFromDiskToUpdateNumber: lastUpdateNumber
	"To use this mechanism, be sure all updates you want to have considered
	are in a folder named 'updates' which resides in the same directory as  
	your image.  Having done that, simply evaluate:  
	  
	Utilities applyUpdatesFromDiskToUpdateNumber: 1234

	and all numbered updates <= lastUpdateNumber not yet in the image will be loaded, in
	numerical order."
	| previousHighest currentUpdateNumber done fileNames aMessage updateDirectory loaded |
	previousHighest _ ChangeSorter highestNumberedChangeSet.
	currentUpdateNumber _ previousHighest.
	done _ false.
	(FileDirectory default directoryNames includes: 'updates')
		ifFalse: [^ self inform: 'Error: cannot find "updates" folder'].
	updateDirectory _ FileDirectory default directoryNamed: 'updates'.
	[done]
		whileFalse: 
			[currentUpdateNumber _ currentUpdateNumber + 1.
			currentUpdateNumber > lastUpdateNumber
				ifTrue: [done _ true]
				ifFalse: 
					[fileNames _ updateDirectory fileNamesMatching: currentUpdateNumber printString , '*'.
					fileNames size > 1 ifTrue: [^ self inform: 'ambiguity -- two files both start with ' , currentUpdateNumber printString , '
(at this point it is probably best to remedy
the situation on disk, then try again.)'].
					fileNames size == 0
						ifTrue: [done _ true]
						ifFalse: [ChangeSorter newChangesFromStream: (updateDirectory readOnlyFileNamed: fileNames first)
								named: fileNames first]]].
	aMessage _ (loaded _ currentUpdateNumber - previousHighest - 1) = 0
				ifTrue: ['No new updates found.']
				ifFalse: [loaded printString , ' update(s) loaded.'].
	self inform: aMessage , '
Highest numbered update is now ' , (currentUpdateNumber - 1) printString , '.'