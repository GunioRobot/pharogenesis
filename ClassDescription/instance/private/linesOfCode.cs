linesOfCode  "InterpreterSimulator linesOfCode 790"
	"An approximate measure of lines of code.
	Includes comments, but excludes blank lines."

	| lines code strm line |
	lines _ 0.
	self selectorsDo: [:sel |
		code _ self sourceCodeAt: sel.
		strm _ ReadStream on: code.
		[strm atEnd] whileFalse:
			[line _ strm upTo: Character cr.
			line isEmpty ifFalse: [lines _ lines+1]]].
	self isMeta
		ifTrue: [^ lines]
		ifFalse: [^ lines + self class linesOfCode]
"
(SystemOrganization categories select: [:c | 'Fabrik*' match: c]) detectSum:
		[:c | (SystemOrganization superclassOrder: c) detectSum: [:cl | cl linesOfCode]] 24878
"