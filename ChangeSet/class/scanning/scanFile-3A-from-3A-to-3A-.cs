scanFile: file from: startPosition to: stopPosition
	| itemPosition item prevChar changeList |
	changeList _ OrderedCollection new.
	file position: startPosition.
'Scanning ', file localName, '...'
	displayProgressAt: Sensor cursorPoint
	from: startPosition to: stopPosition
	during: [:bar |
	[file position < stopPosition] whileTrue:[
		bar value: file position.
		[file atEnd not and: [file peek isSeparator]]
			whileTrue: [prevChar _ file next].
		(file peekFor: $!) ifTrue:[
			(prevChar = Character cr or: [prevChar = Character lf])
				ifTrue: [changeList addAll: (self scanCategory: file)].
		] ifFalse:[
			itemPosition _ file position.
			item _ file nextChunk.
			file skipStyleChunk.
			item size > 0 ifTrue:[
				changeList add: (ChangeRecord new file: file position: itemPosition type: #doIt).
			].
		].
	]].
	^changeList