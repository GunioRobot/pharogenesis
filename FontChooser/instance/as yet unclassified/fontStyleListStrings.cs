fontStyleListStrings
	"names of simulated styles are enclosed in parenthesis"
	^self fontStyleList collect: [:fontFamilyMember | | s |
		s := fontFamilyMember styleName.
		fontFamilyMember simulated
			ifTrue:[s := '(', s, ')'].
		s]