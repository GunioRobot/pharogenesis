inspectElement
	| sel selSize countString count |
	"Create and schedule an Inspector on an element of the receiver's model's currently selected collection."

	self selectionIndex = 0 ifTrue: [^ self changed: #flash].
	((sel _ self selection) isKindOf: SequenceableCollection) ifFalse:
		[^ sel inspect].
	(selSize _ sel size) == 1 ifTrue: [^ sel first inspect].
	selSize <= 10 ifTrue:
		[count _ (SelectionMenu selections: (1 to: selSize) asArray) startUpWithCaption: 'which element?'.
		count ifNil: [^ self] ifNotNil: [^ (sel at: count) inspect]].

	countString _ FillInTheBlank request: 'Which element? (1 - ', selSize printString, ')' initialAnswer: '1'.
	countString isEmptyOrNil ifTrue: [^ self].
	count _ Integer readFrom: (ReadStream on: countString).
	(count > 0 and: [count <= selSize])
		ifTrue:
			[(sel  at: count) inspect]
		ifFalse:
			[self beep]