mostRecentlySubmittedMessage
	"Answer a string indicating the most recently submitted method that is still extant"

	self flag: #mref.	"fix for faster references to methods"

	self assureMostRecentSubmissionExists.
	^ RecentSubmissions last asStringOrText asString