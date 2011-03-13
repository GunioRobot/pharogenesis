handleKeyDown: anEvent
	"System level event handling."
	anEvent wasHandled ifTrue:[^self].
	(self handlesKeyboard: anEvent) ifFalse:[^self].
	anEvent wasHandled: true.
	^self keyDown: anEvent