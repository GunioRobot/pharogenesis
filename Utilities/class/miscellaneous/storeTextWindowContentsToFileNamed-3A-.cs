storeTextWindowContentsToFileNamed: aName
	"Utilities storeTextWindowContentsToFileNamed: 'TextWindows'"
	| windows aDict assoc aRefStream textToUse aTextView |
	aDict _ Dictionary new.
	Smalltalk isMorphic
		ifTrue:
			[windows _ World submorphs select: [:m | m isKindOf: SystemWindow].
			windows do:
				[:w | assoc _ w titleAndPaneText.
				assoc ifNotNil:
					[w holdsTranscript ifFalse:
						[aDict add: assoc]]]]
		ifFalse:
			[windows _ ScheduledControllers controllersSatisfying:
				[:c | (c model isMemberOf: StringHolder) or: [c model isKindOf: Workspace]].
			windows do:
				[:aController | 
					aTextView _ aController view subViews detect: [:m | m isKindOf: PluggableTextView] ifNone: [nil].
					textToUse _ aTextView
						ifNil:		[aController model contents]
						ifNotNil:	[aTextView controller text].  "The latest edits, whether accepted or not"
					aDict at: aController view label put: textToUse]].

	aDict size = 0 ifTrue: [^ self inform: 'no windows found to export.'].

	aRefStream _ ReferenceStream fileNamed: aName.
	aRefStream nextPut: aDict.
	aRefStream close.
	self inform: 'Done!  ', aDict size printString, ' window(s) exported.'