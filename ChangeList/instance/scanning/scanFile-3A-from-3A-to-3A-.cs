scanFile: aFile from: startPosition to: stopPosition
	| itemPosition item prevChar |
	file _ aFile.
	changeList _ OrderedCollection new.
	list _ OrderedCollection new.
	listIndex _ 0.
	file position: startPosition.
'Scanning ', aFile localName, '...'
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
			[(prevChar = Character cr or: [prevChar = Character lf])
				ifTrue: [self scanCategory]]
		ifFalse:
			[itemPosition _ file position.
			item _ file nextChunk.
			file skipStyleChunk.
			item size > 0 ifTrue:
				[self addItem: (ChangeRecord new file: file position: itemPosition type: #doIt)
					text: 'do it: ' , (item contractTo: 50)]]]].
	listSelections _ Array new: list size withAll: false