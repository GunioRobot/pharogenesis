installKeyDecodeTable
	"Create a decode table that swaps some keys if 
	Preferences swapControlAndAltKeys is set"
	KeyDecodeTable _ Dictionary new.
	Preferences duplicateControlAndAltKeys 
		ifTrue: [ self defaultCrossPlatformKeys do:
				[ :c | self installDuplicateKeyEntryFor: c ] ].
	Preferences swapControlAndAltKeys 
		ifTrue: [ self defaultCrossPlatformKeys do:
				[ :c | self installSwappedKeyEntryFor: c ] ].
	Preferences duplicateAllControlAndAltKeys
		ifTrue: [ (Character allCharacters select: [:ea | ea isAlphaNumeric]) do:
				[ :c | self installDuplicateKeyEntryFor: c ] ].
