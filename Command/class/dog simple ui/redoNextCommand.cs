redoNextCommand
	| w |
	^(w := self currentWorld) == nil ifFalse:[w commandHistory redoNextCommand]