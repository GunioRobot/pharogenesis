initialize
	"TestRunner initialize"
	self registerInFlapsRegistry.
	self registerPreferences.
	(Preferences windowColorFor: #TestRunner) = Color white
		ifTrue: [ Preferences setWindowColorFor: #TestRunner to: (Color colorFrom: self windowColorSpecification pastelColor) ].
	(TheWorldMenu respondsTo: #registerOpenCommand:) ifTrue: [
		TheWorldMenu unregisterOpenCommand: 'Test Runner'.
		TheWorldMenu registerOpenCommand: {'SUnit Test Runner'. {self. #open}}].

	
