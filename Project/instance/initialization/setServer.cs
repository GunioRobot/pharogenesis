setServer
	"Mark me as a new project.  See if a server is known, remember it."

	self projectParameters at: #exportState put: #nacent.
	(urlList == nil or: [urlList size = 0]) ifTrue: [
		urlList _ parentProject urlList].