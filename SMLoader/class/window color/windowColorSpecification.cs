windowColorSpecification
	"Answer a WindowColorSpec object that declares my preference."

	^WindowColorSpec
		classSymbol: self name
		wording: 'Package Loader'
		brightColor: Color yellow muchLighter duller
		pastelColor: Color yellow veryMuchLighter duller
		helpMessage: 'The SqueakMap Package Loader'