initialize

	self flag: #bob.		"need to decide better initial types"

	super initialize.
	ipAddress _ '???'.
	accessAttempts _ attempsDenied _ 0.
	lastRequests _ OrderedCollection new.
	acceptableTypes _ Set withAll: EToyIncomingMessage allTypes.

 