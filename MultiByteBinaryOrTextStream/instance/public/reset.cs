reset

	super reset.
	isBinary ifNil: [isBinary _ false].
	collection class == ByteArray ifTrue: ["Store as String and convert as needed."
		collection _ collection asString.
		isBinary _ true].

	self converter. "ensure that we have a converter."