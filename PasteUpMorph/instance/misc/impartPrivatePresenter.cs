impartPrivatePresenter
	presenter ifNil:
		[presenter _ Presenter new associatedMorph: self.
		presenter standardPlayer]