newFromFile: aStream  "World addMorph: CrosticPanel new"

	| quoteWithBlanks citation clue numberLine numbers clues answers indexableQuote quotePanel crosticPanel buttonRow quoteWidth |
	quoteWithBlanks _ aStream nextLine.
	quoteWithBlanks _ quoteWithBlanks asUppercase select: [:c | c isLetter or: [' -' includes: c]].
	indexableQuote _ quoteWithBlanks select: [:c | c isLetter].
	citation _ aStream nextLine.
	aStream nextLine.
	clues _ OrderedCollection new.
	answers _ OrderedCollection new.
	[aStream atEnd] whileFalse:
		[clue _ aStream nextLine.
		"Transcript cr; show: clue."
		clues addLast: clue.
		numberLine _ aStream nextLine.
		numbers _ Scanner new scanTokens: numberLine.
		answers addLast: numbers].

	"Consistency check: "
	(citation asUppercase select: [:c | c isLetter]) =
		(String withAll: (answers collect: [:a | indexableQuote at: a first]))
		ifFalse: [self error: 'mal-formed crostic file'].
	
	crosticPanel _ super new.
	quotePanel _ CrosticQuotePanel new quote: quoteWithBlanks answers: answers cluesPanel: crosticPanel.
	crosticPanel color: quotePanel firstSubmorph color;
		quote: indexableQuote clues: clues answers: answers quotePanel: quotePanel.
	buttonRow _ crosticPanel buttonRow.
	quoteWidth _ (crosticPanel width + quotePanel firstSubmorph width)
					max: buttonRow width.
	quotePanel extent: quoteWidth @ 9999.
	crosticPanel addMorph: quotePanel.
	^ crosticPanel breakColumnAndResizeWithButtons: buttonRow

