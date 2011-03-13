reportField: aString to: aBlock
	"Evaluate the given block with the field name a value in the given field. Do nothing if the field is malformed."

	| s fieldName fieldValue |
	(aString includes: $:) ifFalse: [^self].
	s _ ReadStream on: aString.
	fieldName _ s upTo: $:.
	fieldValue _ s upToEnd withBlanksTrimmed.
	fieldValue isEmpty ifFalse: [aBlock value: fieldName value: fieldValue].
