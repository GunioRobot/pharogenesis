choosePartNameSilently

	super choosePartNameSilently.
	(self world model class)
		compile: self buttonUpSelector
		classified: 'scripts'
		notifying: nil.
