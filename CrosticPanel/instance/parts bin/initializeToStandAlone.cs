initializeToStandAlone
	| aStream quoteWithBlanks indexableQuote citation clue numberLine numbers buttonRow quoteWidth |
	super initializeToStandAlone.
	aStream := ReadStream on: self class sampleFile.
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
	quotePanel := CrosticQuotePanel new
				quote: quoteWithBlanks
				answers: answers
				cluesPanel: self.
	self color: quotePanel firstSubmorph color;
		
		quote: indexableQuote
		clues: clues
		answers: answers
		quotePanel: quotePanel.
	buttonRow := self buttonRow.
	quoteWidth := self width + quotePanel firstSubmorph width max: buttonRow width.
	quotePanel extent: quoteWidth @ 9999.
	self addMorph: quotePanel.
	self breakColumnAndResizeWithButtons: buttonRow