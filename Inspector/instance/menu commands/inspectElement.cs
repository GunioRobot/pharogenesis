inspectElement
	| sel selSize countString count nameStrs |
	"Create and schedule an Inspector on an element of the receiver's model's currently selected collection."

	self selectionIndex = 0 ifTrue: [^ self changed: #flash].
	((sel _ self selection) isKindOf: SequenceableCollection) ifFalse:
		[(sel isKindOf: MorphExtension) ifTrue: [^ sel inspectElement].
		^ sel inspect].
	(selSize _ sel size) == 1 ifTrue: [^ sel first inspect].
	selSize <= 20 ifTrue:
		[nameStrs _ (1 to: selSize) asArray collect: [:ii | 
			ii printString, '   ', (((sel at: ii) printStringLimitedTo: 25) replaceAll: Character cr with: Character space)].
		count _ PopUpMenu withCaption: 'which element?' chooseFrom: nameStrs.
		count = 0 ifTrue: [^ self].
		^ (sel at: count) inspect].

	countString _ FillInTheBlank request: 'Which element? (1 to ', selSize printString, ')' initialAnswer: '1'.
	countString isEmptyOrNil ifTrue: [^ self].
	count _ Integer readFrom: (ReadStream on: countString).
	(count > 0 and: [count <= selSize])
		ifTrue: [(sel at: count) inspect]
		ifFalse: [Beeper beep]