applyUpdatesFromDiskToUpdateNumber: lastUpdateNumber stopIfGap: stopIfGapFlag 
	"To use this mechanism, be sure all updates you want to have considered 
	are in a folder named 'updates' which resides in the same directory as  
	your image. Having done that, simply evaluate:  
	 
	Utilities applyUpdatesFromDiskToUpdateNumber: 1234 stopIfGap: false  
	 
	and all numbered updates <= lastUpdateNumber not yet in the image will 
	be loaded in numerical order."
	| previousHighest currentUpdateNumber done fileNames aMessage updateDirectory loaded |
	updateDirectory := self getUpdateDirectoryOrNil.
	updateDirectory ifNil: [^ self].
	previousHighest := SystemVersion current highestUpdate.
	currentUpdateNumber := previousHighest.
	done := false.
	loaded := 0.
	[done]
		whileFalse: [currentUpdateNumber := currentUpdateNumber + 1.
			currentUpdateNumber > lastUpdateNumber
				ifTrue: [done := true]
				ifFalse: [fileNames := updateDirectory fileNamesMatching: currentUpdateNumber printString , '*'.
					fileNames size > 1
						ifTrue: [^ self inform: 'ambiguity -- two files both start with ' , currentUpdateNumber printString , '
(at this point it is probably best to remedy
the situation on disk, then try again.)'].
					fileNames size == 0
						ifTrue: [Transcript cr; show: 'gap in updates from disk for update number '; print: currentUpdateNumber; show: ' found...'.
							done := stopIfGapFlag]
						ifFalse: [ChangeSet
								newChangesFromStream: (updateDirectory readOnlyFileNamed: fileNames first)
								named: fileNames first.
							SystemVersion current registerUpdate: currentUpdateNumber.
							loaded := loaded + 1]]].
	aMessage := loaded = 0
				ifTrue: ['No new updates found.']
				ifFalse: [loaded printString , ' update(s) loaded.'].
	self inform: aMessage , '
Highest numbered update is now ' , (currentUpdateNumber - 1) printString , '.'