minCellSize
	"Layout specific. This property specifies the minimal size of a table cell."
	| props |
	props _ self layoutProperties.
	^props ifNil:[0] ifNotNil:[props minCellSize].