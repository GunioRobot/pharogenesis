windowColorSpecification
	"Answer a WindowColorSpec object that declares my preference"

	^ WindowColorSpec
		classSymbol: self name
		wording: 'TestRunner'
		brightColor: (Color r: 0.650 g: 0.753 b: 0.976)
		pastelColor: (Color r: 0.780 g: 0.860 b: 1.0)
		helpMessage: 'The Camp Smalltalk SUnit test tool'
