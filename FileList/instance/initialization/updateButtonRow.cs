updateButtonRow
	"Dynamically update the contents of the button row, if any."

	| aWindow aRow |
	Smalltalk isMorphic ifFalse: [^self].
	aWindow := self dependents 
				detect: [:m | (m isSystemWindow) and: [m model == self]]
				ifNone: [^self].
	aRow := aWindow findDeepSubmorphThat: [:m | m hasProperty: #buttonRow]
				ifAbsent: [^self].
	aRow submorphs size - 4 timesRepeat: [aRow submorphs last delete].
	self dynamicButtonServices do: 
			[:service | 
			aRow addMorphBack: (service buttonToTriggerIn: self).
			service addDependent: self]