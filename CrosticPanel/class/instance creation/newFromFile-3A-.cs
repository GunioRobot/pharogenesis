newFromFile: aStream 
	"World addMorph: CrosticPanel new"
	"World addMorph: (CrosticPanel newFromFile: (FileStream 
	readOnlyFileNamed: 'first.crostic'))"
	| quoteWithBlanks citation clue numberLine numbers clues answers indexableQuote quotePanel crosticPanel buttonRow quoteWidth |
	aStream next asciiValue = 31 & (aStream next asciiValue = 139)
		ifTrue: ["It's gzipped..."
			aStream skip: -2.
			^ self newFromFile: aStream asUnZippedStream ascii].
	aStream skip: -2.
	quoteWithBlanks := aStream nextLine.
	quoteWithBlanks := quoteWithBlanks asUppercase
				select: [:c | c isLetter
						or: [' -' includes: c]].
	indexableQuote := quoteWithBlanks
				select: [:c | c isLetter].
	citation := aStream nextLine.
	aStream nextLine.
	clues := OrderedCollection new.
	answers := OrderedCollection new.
	[aStream atEnd]
		whileFalse: [clue := aStream nextLine.
			"Transcript cr; show: clue."
			clues addLast: clue.
			numberLine := aStream nextLine.
			numbers := Scanner new scanTokens: numberLine.
			answers addLast: numbers].
	aStream close.
	"Consistency check:"
	(citation asUppercase
			select: [:c | c isLetter])
			= (String
					withAll: (answers
							collect: [:a | indexableQuote at: a first]))
		ifFalse: [self error: 'mal-formed crostic file' translated].
	crosticPanel := super new.
	quotePanel := CrosticQuotePanel new
				quote: quoteWithBlanks
				answers: answers
				cluesPanel: crosticPanel.
	crosticPanel color: quotePanel firstSubmorph color;
		
		quote: indexableQuote
		clues: clues
		answers: answers
		quotePanel: quotePanel.
	buttonRow := crosticPanel buttonRow.
	quoteWidth := crosticPanel width + quotePanel firstSubmorph width max: buttonRow width.
	quotePanel extent: quoteWidth @ 9999.
	crosticPanel addMorph: quotePanel.
	^ crosticPanel breakColumnAndResizeWithButtons: buttonRow