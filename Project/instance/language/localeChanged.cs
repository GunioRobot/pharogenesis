localeChanged
	"Set the project's natural language as indicated"

	| |
	self localeID = LocaleID current
		ifTrue: [^self].

	self projectParameterAt: #localeID put: LocaleID current.

	self updateLocaleDependents