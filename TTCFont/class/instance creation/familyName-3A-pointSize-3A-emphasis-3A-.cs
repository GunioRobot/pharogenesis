familyName: n pointSize: s emphasis: code

	"(TTCFont familyName: 'BitstreamVeraSans' pointSize: 12 emphasis: 0)"
	| t ret index |
	t _ self registry at: n asSymbol ifAbsent: [#()].
	t isEmpty ifTrue: [
		t _ (TextConstants at: #DefaultTextStyle) fontArray.
		ret _ t first.
		ret pointSize >= s ifTrue: [^ ret emphasis: code].
		index _ 2.
		[index <= t size and: [(t at: index) pointSize <= s]] whileTrue: [
			ret _ t at: index.
			index _ index + 1.
		].
		^ ret emphasis: code.
	].
	^ ((TextStyle named: n) addNewFontSize: s) emphasis: code.
