makeDetachable
	presenter
		ifNil:
			[self impartPrivatePresenter.
			self borderWidth: 1;  borderColor: Color green darker]
		ifNotNil:
			[self inform: 'This view is ALREADY detachable']