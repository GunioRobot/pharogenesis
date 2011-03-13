disableTableLayout
	"Layout specific. Disable laying out the receiver in table layout"
	| props |
	props _ self layoutProperties.
	^props ifNil:[false] ifNotNil:[props disableTableLayout].