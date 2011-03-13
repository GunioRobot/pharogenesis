layoutInset
	"Return the extra inset for layouts"
	| props |
	props _ self layoutProperties.
	^props ifNil:[0] ifNotNil:[props layoutInset].