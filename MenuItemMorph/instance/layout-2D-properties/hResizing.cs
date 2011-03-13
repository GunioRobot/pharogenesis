hResizing
	"Default to #spaceFill"
	| props |
	props _ self layoutProperties.
	^props ifNil:[#spaceFill] ifNotNil:[props hResizing].