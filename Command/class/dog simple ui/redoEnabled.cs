redoEnabled
	| w |
	^(w _ self currentWorld) == nil ifTrue:[false] ifFalse:[w commandHistory redoEnabled]