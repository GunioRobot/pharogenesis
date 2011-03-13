readField: fieldName fromString: aString fields: sharedFields base: instVarBase
	"This message should be overridden in subclasses to recognize the types for the various fields.  If a fieldName is not recognized below, super will invoke this method at the end."

	(sharedFields includes: fieldName) ifTrue:
		[^ self instVarAt: instVarBase + (sharedFields indexOf: fieldName)
				put: (Compiler evaluate: aString)].

	otherFields ifNil: [otherFields _ Dictionary new].
	otherFields at: fieldName put: (Compiler evaluate: aString)
