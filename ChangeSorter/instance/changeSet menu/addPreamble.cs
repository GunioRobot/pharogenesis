addPreamble
	myChangeSet assurePreambleExists.
	self okToChange ifTrue:
		[currentClassName _ nil.
		currentSelector _ nil.
		self showChangeSet: myChangeSet]