checkForNewerVersionAndLoad

	self withProgressDo: [
		project loadFromServer
	] 

