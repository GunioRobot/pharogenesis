indentationOfLineIndex: lineIndex ifBlank: aBlock
	"Answer the number of leading tabs in the line at lineIndex.  If there are
	 no visible characters, pass the number of tabs to aBlock and return its value.
	 If the line is word-wrap overflow, back up a line and recur."

	| arrayIndex first last cr |
	cr _ Character cr.
	arrayIndex _ lineIndex.
	[first _ (lines at: arrayIndex) first.
	 first > 1 and: [(text string at: first - 1) ~~ cr]] whileTrue: "word wrap"
		[arrayIndex _ arrayIndex - 1].
	last _ (lines at: arrayIndex) last.
	
	^(text string copyFrom: first to: last) indentationIfBlank: aBlock.
