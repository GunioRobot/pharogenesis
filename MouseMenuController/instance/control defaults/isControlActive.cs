isControlActive 
	"In contrast to class Controller, only blue button but not yellow button
	events will end the receiver's control loop."

	^ self viewHasCursor and: [sensor blueButtonPressed not]