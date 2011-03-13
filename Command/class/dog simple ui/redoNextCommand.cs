redoNextCommand
	| w |
	^(w _ self currentWorld) == nil ifFalse:[w commandHistory redoNextCommand]