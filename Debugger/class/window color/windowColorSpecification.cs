windowColorSpecification
	"Answer a WindowColorSpec object that declares my preference"

	^ WindowColorSpec classSymbol: self name  wording: 'Debugger' brightColor: #lightRed pastelColor: #veryPaleRed helpMessage: 'The system debugger.'