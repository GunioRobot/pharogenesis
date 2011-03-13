expandFullBoundsForRolloverBorder: aRectangle
	| delta |
	delta _ self valueOfProperty: #rolloverWidth ifAbsent: [10@10].
	^aRectangle expandBy: delta.

