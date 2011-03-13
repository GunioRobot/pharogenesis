indentationOfLineIndex: lineIndex ifBlank: aBlock
	"Answer the number of leading tabs in the line at lineIndex.  If there are
	 no visible characters, pass the number of tabs to aBlock and return its value.
	 If the line is word-wrap overflow, back up a line and recur."

	| arrayIndex first last reader leadingTabs lastSeparator cr tab ch |
	cr := Character cr.
	tab := Character tab.
	arrayIndex := lineIndex.
	[first := (lines at: arrayIndex) first.
	 first > 1 and: [(text string at: first - 1) ~~ cr]] whileTrue: "word wrap"
		[arrayIndex := arrayIndex - 1].
	last := (lines at: lastLine) last.
	reader := ReadStream on: text string from: first to: last.
	leadingTabs := 0.
	[reader atEnd not and: [(ch := reader next) == tab]]
		whileTrue: [leadingTabs := leadingTabs + 1].
	lastSeparator := first - 1 + leadingTabs.
	[reader atEnd not and: [ch isSeparator and: [ch ~~ cr]]]
		whileTrue: [lastSeparator := lastSeparator + 1. ch := reader next].
	lastSeparator = last | (ch == cr)
		ifTrue: [^aBlock value: leadingTabs].
	^leadingTabs