reportField: aString to: aBlock
	"Evaluate the given block with the field name a value in the given field. Do nothing if the field has an empty value part."

	| s fieldName fieldValue |
	s _ ReadStream on: aString.
	fieldName _ (s upTo: $:) asLowercase.
	s skipSeparators.
	(s atEnd) ifFalse: [
		"field is not empty"
		fieldValue _ s upToEnd.
		aBlock value: fieldName value: fieldValue].
