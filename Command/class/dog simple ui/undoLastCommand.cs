undoLastCommand
	| w |
	^(w _ self currentWorld) == nil ifFalse:[w commandHistory undoLastCommand]