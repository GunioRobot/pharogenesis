startUpSegmented: segmentHeight withCaption: captionOrNil at: location
	"This menu is too big to fit comfortably on the screen.
	Break it up into smaller chunks, and manage the relative indices.
	Inspired by a special-case solution by Reinier van Loon."
"
(PopUpMenu labels: (String streamContents: [:s | 1 to: 100 do: [:i | s print: i; cr]. s skip: -1])
		lines: (5 to: 100 by: 5)) startUpWithCaption: 'Give it a whirl...'.
"
	| nLines nLinesPer allLabels from to subset subLines index |
	nLines _ (frame height - 4) // marker height.
	allLabels := labelString findTokens: Character cr asString.
	lineArray ifNil: [lineArray _ Array new].
	nLinesPer _ segmentHeight // marker height - 2.
	from := 1.
	[ true ] whileTrue:
		[to := (from + nLinesPer) min: nLines.
		subset := allLabels copyFrom: from to: to.
		subset add: (to = nLines ifTrue: ['start over...'] ifFalse: ['more...'])
			before: subset first.
		subLines _ lineArray select: [:n | n >= from] thenCollect: [:n | n - (from-1) + 1].
		subLines _ (Array with: 1) , subLines.
		index := (PopUpMenu labels: subset asStringWithCr lines: subLines) startUpWithCaption: captionOrNil at: location.
		index = 1
			ifTrue: [from := to + 1.
					from > nLines ifTrue: [ from := 1 ]]
			ifFalse: [index = 0 ifTrue: [^ 0].
					^ from + index - 2]]