addTime: timeAmount
	"Answer a Time that is timeInterval after the receiver. timeInterval is an 
	instance of Date or Time."

	^Time fromSeconds: self asSeconds + timeAmount asSeconds