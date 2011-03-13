scanFile: aFile from: startPosition to: stopPosition
	| itemPosition item prevChar |
	file _ aFile.
	changeList _ OrderedCollection new.
	list _ OrderedCollection new.
	listIndex _ 0.
	file position: startPosition.
'Scanning changes...'
	displayProgressAt: Sensor cursorPoint
	from: startPosition to: stopPosition
	during: [:bar |
	[file position < stopPosition]
		whileTrue:
		[bar value: file position.
		[file atEnd not and: [file peek isSeparator]]
				whileTrue: [prevChar _ file next].
		(file peekFor: $!)
		ifTrue:
			[prevChar = Character cr ifTrue: [self scanCategory]]
		ifFalse:
			[itemPosition _ file position.
			item _ file nextChunk.
			item size > 0 ifTrue:
				[self addItem: (ChangeRecord new file: file position: itemPosition type: #doIt)
					text: 'do it: ' , (item contractTo: 50)]]]].
	listSelections _ Array new: list size withAll: false