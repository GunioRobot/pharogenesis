copyName
	"Copy the name of the current variable, so the user can paste it into the window below and work with is.  If collection, do (xxx at: 1). "

	| sel aClass |
	self selectionUnmodifiable ifTrue: [^ self changed: #flash].
	(aClass _ self object class) isVariable ifTrue: [^ self changed: #flash].

	sel _ aClass allInstVarNames at: selectionIndex - 2.
	(self selection isKindOf: Collection) ifTrue: [sel _ '(',sel,' at: 1)'].
	Clipboard clipboardText: sel asText.	"no undo allowed"