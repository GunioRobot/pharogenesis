vResizing
	"Default to #shrinkWrap"
	| props |
	props _ self layoutProperties.
	^props ifNil:[#shrinkWrap] ifNotNil:[props vResizing].