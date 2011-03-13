cellInset
	"Layout specific. This property specifies an extra inset for each cell in the layout."
	| props |
	props _ self layoutProperties.
	^props ifNil:[0] ifNotNil:[props cellInset].