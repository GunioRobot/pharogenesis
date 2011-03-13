labels: labelString lines: lineArray selections: selectorArray
	"Supports MVC-compatible menu creation protocol"
	| labelArray lineNo |
	labelArray _ labelString findTokens: String cr.
	lineNo _ 1.
	labelArray with: selectorArray do:
		[:label :sel |
		self add: label action: sel.
		(lineArray includes: lineNo) ifTrue: [self addLine].
		lineNo _ lineNo + 1]