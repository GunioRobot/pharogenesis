untranslatedHelpMessage
	"Check if there is a getterSetterHelpMessage. 
	Otherwise try the normal help message or return nil."

	^(self propertyAt: #getterSetterHelpMessage ifAbsent: [nil])
		ifNil: [(self propertyAt: #helpMessage ifAbsent: [nil])]