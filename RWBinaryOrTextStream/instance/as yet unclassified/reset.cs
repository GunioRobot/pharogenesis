reset
	"Set the receiver's position to the beginning of the sequence of objects."

	super reset.
	isBinary ifNil: [isBinary _ false].
	collection class == ByteArray ifTrue: ["Store as String and convert as needed."
		collection _ collection asString.
		isBinary _ true].
