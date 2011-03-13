presenter
	presenter ifNil:
		[presenter _ Presenter new associatedMorph: self.
		presenter initializeToggles].
	^ presenter