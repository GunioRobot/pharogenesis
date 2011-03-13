editScript: evt

	self nameInModel ifNil: [self choosePartNameSilently].
	evt hand attachMorph:
		(self scriptEditorFor: 'processSamples').
