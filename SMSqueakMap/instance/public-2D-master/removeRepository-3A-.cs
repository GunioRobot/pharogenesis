removeRepository: aRepository
	"Log it in the logfile and delete it."
	
	self deleteRepository: aRepository.
	self logDelete: aRepository.
	^aRepository