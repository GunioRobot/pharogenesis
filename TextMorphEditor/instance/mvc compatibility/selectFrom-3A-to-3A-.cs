selectFrom: start to: stop
	"Select the specified characters inclusive."
	self selectInvisiblyFrom: start to: stop.
	self closeTypeIn.
	paragraph selectionStart: startBlock selectionStop: stopBlock