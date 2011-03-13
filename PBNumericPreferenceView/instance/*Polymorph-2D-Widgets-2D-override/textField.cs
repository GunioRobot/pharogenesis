textField
	"Answer a text field for the preference."
	
	^UITheme current
		newAutoAcceptTextEntryIn: World
		for: self
		get: #preferenceValue
		set: #preferenceValue:
		class: String
		getEnabled: nil
		help: nil