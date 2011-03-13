buildButtonsFor: model 
	"Answer a collection of handy buttons for the Celeste user interface."
	| buttons b |
	buttons _ OrderedCollection new.
	b _ self buildButtonFromSpec: self specForSubjectFilterButton forModel: model.
	buttons add: b.
	true
		ifFalse: ["Skip these buttons..."
			b _ self buildFromFilterButtonForModel: model.
			buttons add: b].
	b _ self buildButtonFromSpec: self specForParticipantFilterButton forModel: model.
	buttons add: b.
	b _ self buildButtonFromSpec: self specForCustomFilterButton forModel: model.
	buttons add: b.
	true
		ifFalse: ["Skip these buttons..."
	b _ self buildButtonFromSpec: self specForCustomFilterMoveButton forModel: model.
	buttons add: b].
	b _ self
				buildButtonFromSpec: self specForComposeButton
				withBlock: [model compose].
	buttons add: b.
	b _ self
				buildButtonFromSpec: self specForReplyButton
				withBlock: [model reply].
	buttons add: b.
	b _ self
				buildButtonFromSpec: self specForForwardButton
				withBlock: [model forward].
	buttons add: b.
	b _ self
				buildButtonFromSpec: self specForMoveAgainButton
				withBlock: [model moveAgain].
	buttons add: b.
	b _ self
				buildButtonFromSpec: self specForDeleteButton
				withBlock: [model deleteMessage].
	buttons add: b.
	^ buttons