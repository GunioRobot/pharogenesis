addTextToTarget

	self targetProperties currentTextInButton ifNil: [
		self targetProperties addTextToButton: '???'.
	].
	self targetProperties currentTextInButton openATextPropertySheet.
