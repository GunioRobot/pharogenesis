testValidateSubclassFormatFix
	"Recompiling Array"
	self
		shouldnt: [ArrayedCollection
				variableSubclass: #Array
				instanceVariableNames: ''
				classVariableNames: ''
				poolDictionaries: ''
				category: 'Collections-Arrayed']
		raise: Error.
	ChangeSet current removeClassChanges: #Array