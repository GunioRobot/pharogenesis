createPageTestWorkspace
	"Used to generate a workspace window for testing page up and page down stuff."
	"Utilities createPageTestWorkspace"

	| numberOfLines maxStringLength minLineCounterSize lineCounterSize offsetSize stream headerConstant prevStart prevStrLen prevLineNumber stringLen lineNumber start log pad charIndex char |
	numberOfLines _ 400.
	maxStringLength _ 22.
	minLineCounterSize _ 3.
	lineCounterSize _ (numberOfLines log asInteger + 1) max: minLineCounterSize.
	offsetSize _ 5.
	stream _ ReadWriteStream on: ''.
	headerConstant _ lineCounterSize + 1 + offsetSize + 1.
	prevStart _ headerConstant negated.
	prevStrLen _ 0.
	prevLineNumber _ 0.
	numberOfLines timesRepeat: [
		stringLen _ maxStringLength atRandom max: 1.
		lineNumber _ prevLineNumber + 1.
		start _ prevStart + prevStrLen + headerConstant + 1.
		prevStart _ start.
		prevStrLen _ stringLen.
		prevLineNumber _ lineNumber.
		log _ lineNumber log asInteger.
		pad _ lineCounterSize - log - 1.
		pad timesRepeat: [stream nextPutAll: '0'].
		stream nextPutAll: lineNumber printString.
		stream space.
		log _ start log asInteger.
		pad _ offsetSize - log - 1.
		pad timesRepeat: [stream nextPutAll: '0'].
		stream nextPutAll: start printString.
		stream space.
		charIndex _ 'a' first asInteger.
		stringLen timesRepeat: [
			char _ Character value: charIndex.
			charIndex _ charIndex + 1.
			stream nextPut: char].
		lineNumber = numberOfLines ifFalse: [stream cr]
		].
	(Workspace new contents: stream contents) openLabel: 'Test Data'.
