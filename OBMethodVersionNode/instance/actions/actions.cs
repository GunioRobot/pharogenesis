actions
	^ {
		self browseAction.
	  	self action: #revert buttonLabel: 'revert' menuLabel: 'revert to selected version'
	}