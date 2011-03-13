checkTape
	"See if this tape was already converted to the new format"
	tape ifNil:[^self].
	tape size = 0 ifTrue:[^self].
	(tape first isKindOf: Association) ifTrue:[tape _ self convertV0Tape: tape].