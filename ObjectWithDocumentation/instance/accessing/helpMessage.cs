helpMessage
	"Check if there is a getterSetterHelpMessage. 
	Otherwise try the normal help message or return nil."

	^ self getterSetterHelpMessage
		ifNil: [(self propertyAt: #helpMessage ifAbsent:
			[self legacyHelpMessage ifNil: [^ nil]]) translated]