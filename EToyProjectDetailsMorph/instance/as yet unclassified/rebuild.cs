rebuild

	| bottomButtons |
	self removeAllMorphs.
	self addARow: {
		self lockedString: 'Please describe this project' translated.
	}.
	self addARow: {
		self lockedString: 'Name:' translated.
		self inAColumnForText: {self fieldForProjectName}
	}.
	self expandedFormat ifTrue: [
		self fieldToDetailsMappings do: [ :each |
			self addARow: {
				self lockedString: each third translated.
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