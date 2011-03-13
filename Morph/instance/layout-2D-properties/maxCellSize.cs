maxCellSize
	"Layout specific. This property specifies the maximum size of a table cell."
	| props |
	props _ self layoutProperties.
	^props ifNil:[SmallInteger maxVal] ifNotNil:[props maxCellSize].