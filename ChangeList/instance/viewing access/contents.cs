contents
	^ self showDiffs
		ifFalse:
			[self undiffedContents]
		ifTrue:
			[self showsVersions
				ifTrue:
					[self diffedVersionContents]
				ifFalse:
					[self contentsDiffedFromCurrent]]