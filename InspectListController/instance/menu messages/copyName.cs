copyName
	"Copy the name of the current variable, so the user can paste it into the window below and work with is.  If collection, do (xxx at: 1). "

	| sel aClass |
	model selectionUnmodifiable ifTrue: [^ view flash].
	(aClass _ model object class) isVariable ifTrue: [^ view flash].

	sel _ aClass allInstVarNames at: model selectionIndex - 2.
	(model selection isKindOf: Collection) ifTrue: [sel _ '(',sel,' at: 1)'].
	ParagraphEditor new clipboardTextPut: sel asText.	"no undo allowed"