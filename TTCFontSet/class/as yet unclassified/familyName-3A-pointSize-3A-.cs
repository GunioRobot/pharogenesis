familyName: n pointSize: s

	"(self familyName: 'MultiMSGothic' pointSize: 14) pointSize"
	| t ret index |
	t _ self registry at: n asSymbol ifAbsent: [#()].
	t isEmpty ifTrue: [
		t _ (TextConstants at: #DefaultTextStyle) fontArray.
		ret _ t first.
		ret pointSize >= s ifTrue: [^ ret].
		index _ 2.
		[index <= t size and: [(t at: index) pointSize <= s]] whileTrue: [
			ret _ t at: index.
			index _ index + 1.
		].
		^ ret.
	].
	^ (TextStyle named: n) addNewFontSize: s.