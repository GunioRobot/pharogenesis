bitsPerComponent
	^depth <= 8 ifTrue:[depth] ifFalse:[8].
