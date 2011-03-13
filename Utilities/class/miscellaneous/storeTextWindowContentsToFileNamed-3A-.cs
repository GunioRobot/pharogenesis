storeTextWindowContentsToFileNamed: aName 
	"Utilities storeTextWindowContentsToFileNamed: 'TextWindows'"
	"there is a reference to World, but this method seems to be unused"
	| windows aDict assoc aRefStream |
	aDict := Dictionary new.
	windows := World submorphs
				select: [:m | m isSystemWindow].
	windows
		do: [:w | 
			assoc := w titleAndPaneText.
			assoc
				ifNotNil: [w holdsTranscript
						ifFalse: [aDict add: assoc]]].
	aDict size = 0
		ifTrue: [^ self inform: 'no windows found to export.'].
	aRefStream := ReferenceStream fileNamed: aName.
	aRefStream nextPut: aDict.
	aRefStream close.
	self inform: 'Done!  ' , aDict size printString , ' window(s) exported.'