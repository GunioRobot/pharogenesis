rebuild

	| bottomButtons |
	self removeAllMorphs.
	self addARow: {
		self lockedString: 'Please describe this project'.
	}.
	self addARow: {
		self lockedString: 'Name:'.
		self inAColumnForText: {self fieldForProjectName}
	}.
	self expandedFormat ifTrue: [
		self fieldToDetailsMappings do: [ :each |
			self addARow: {
				self lockedString: each third.
				self inAColumnForText: {(self genericTextFieldNamed: each first) height: each fourth}
			}.
		].
	].
	bottomButtons _ self expandedFormat ifTrue: [
		{
			self okButton.
			self cancelButton.
		}
	] ifFalse: [
		{
			self okButton.
			self expandButton.
			self cancelButton.
		}
	].
	self addARow: bottomButtons.
	self fillInDetails.