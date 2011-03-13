instanceVariableNames: instVarString 
	"Declare additional named variables for my instance."
	| newMeta invalid ok |
	newMeta _ self copyForValidation.
	invalid _ newMeta
				subclassOf: superclass
				oldClass: self
				instanceVariableNames: instVarString
				variable: false
				words: true
				pointers: true
				ifBad: [^false].
	(invalid  "But since invalid doesn't get set by adding instVars..."
		or: [instVarString ~= self instanceVariablesString])
		ifTrue: [newMeta validateFrom: self
					in: Smalltalk
					instanceVariableNames: true
					methods: true.
				Smalltalk changes changeClass: self]