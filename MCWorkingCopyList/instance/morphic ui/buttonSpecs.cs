buttonSpecs
	^ #(
		(Add addWorkingCopy 'add working copy')
		(Browse browseWorkingCopy 'browse working copy' hasWorkingCopy)
		(History viewHistory 'view working copy history' hasWorkingCopy)
		(Changes viewChanges 'view working copy changes' hasWorkingCopy)
		(Save saveVersion 'save the working copy to a new version' hasWorkingCopy)
		)