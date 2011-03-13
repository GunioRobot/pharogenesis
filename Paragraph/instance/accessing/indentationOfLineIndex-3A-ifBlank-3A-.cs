indentationOfLineIndex: lineIndex ifBlank: aBlock
	"Answer the number of leading tabs in the line at lineIndex.  If there are
	 no visible characters, pass the number of tabs to aBlock and return its value.
	 If the line is word-wrap overflow, back up a line and recur."

	| arrayIndex first last reader leadingTabs lastSeparator cr tab ch |
	cr _ Character cr.
	tab _ Character tab.
	arrayIndex _ lineIndex.
	[first _ (lines at: arrayIndex) first.
	 first > 1 and: [(text string at: first - 1) ~~ cr]] whileTrue: "word wrap"
		[arrayIndex _ arrayIndex - 1].
	last _ (lines at: lastLine) last.
	reader _ ReadStream on: text string from: first to: last.
	leadingTabs _ 0.
	[reader atEnd not and: [(ch _ reader next) == tab]]
		whileTrue: [leadingTabs _ leadingTabs + 1].
	lastSeparator _ first - 1 + leadingTabs.
	[reader atEnd not and: [ch isSeparator and: [ch ~~ cr]]]
		whileTrue: [lastSeparator _ lastSeparator + 1. ch _ reader next].
	lastSeparator = last | (ch == cr)
		ifTrue: [^aBlock value: leadingTabs].
	^leadingTabs