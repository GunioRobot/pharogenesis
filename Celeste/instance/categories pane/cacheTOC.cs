cacheTOC
	"Caches a version of the TOC"
	| s tocString tocStringColumns |
	self initializeTocLists.
	currentTOC _ OrderedCollection new: currentMessages size.
	'Processing ' , currentMessages size printString , ' messages.'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: currentMessages size
		during: [:bar | 1
				to: currentMessages size
				do: [:i | 
					bar value: i.
					s _ WriteStream
								on: (String new: 100).
					s nextPutAll: i printString;
						 space.
					(self tocLists at: 1)
						add: i printString.
					[s position < 4]
						whileTrue: [s space].
					tocString _ mailDB
								getTOCstring: (currentMessages at: i).
					"columns from the database are 5"
					tocStringColumns _ mailDB
								getTOCstringAsColumns: (currentMessages at: i).
					s nextPutAll: tocString.
					currentTOC add: s contents.
					(self tocLists at: 2)
						add: ((tocStringColumns at: 5)
								ifTrue: ['@']
								ifFalse: [' ']).
					(self tocLists at: 3)
						add: (tocStringColumns at: 1).
					(self tocLists at: 4)
						add: (tocStringColumns at: 2).
					(self tocLists at: 5)
						add: (tocStringColumns at: 4).
					(self tocLists at: 6)
						add: (tocStringColumns at: 3)]].
	currentTOC _ currentTOC asArray.
	(currentMessages includes: currentMsgID)
		ifFalse: [currentMsgID _ nil]