maybeEmptyTrash
	(self confirm: 'Do you really want to empty the trash?')
		ifTrue: [self emptyScrapsBook]