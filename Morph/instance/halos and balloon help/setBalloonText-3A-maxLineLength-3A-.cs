setBalloonText: stringOrText maxLineLength: aLength
	"Set receiver's balloon help text. Pass nil to remove the help."

	(extension isNil and: [stringOrText isNil]) ifTrue: [^ self].
	self assureExtension balloonText: (stringOrText
		ifNil: [nil]
		ifNotNil: [stringOrText asString withNoLineLongerThan: aLength])