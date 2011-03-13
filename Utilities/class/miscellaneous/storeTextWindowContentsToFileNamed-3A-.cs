storeTextWindowContentsToFileNamed: aName
	"Utilities storeTextWindowContentsToFileNamed: 'TextWindows'"
	| windows aDict assoc aRefStream textToUse aTextView |

	"there is a reference to World, but this method seems to be unused"


	aDict := Dictionary new.
	Smalltalk isMorphic
		ifTrue:
			[windows := World submorphs select: [:m | m isSystemWindow].
			windows do:
				[:w | assoc := w titleAndPaneText.
				assoc ifNotNil:
					[w holdsTranscript ifFalse:
						[aDict add: assoc]]]]
		ifFalse:
			[windows := ScheduledControllers controllersSatisfying:
				[:c | (c model isKindOf: StringHolder)].
			windows do:
				[:aController | 
					aTextView := aController view subViews detect: [:m | m isKindOf: PluggableTextView] ifNone: [nil].
					textToUse := aTextView
						ifNil:		[aController model contents]
						ifNotNil:	[aTextView controller text].  "The latest edits, whether accepted or not"
					aDict at: aController view label put: textToUse]].

	aDict size = 0 ifTrue: [^ self inform: 'no windows found to export.'].

	aRefStream := ReferenceStream fileNamed: aName.
	aRefStream nextPut: aDict.
	aRefStream close.
	self inform: 'Done!  ', aDict size printString, ' window(s) exported.'