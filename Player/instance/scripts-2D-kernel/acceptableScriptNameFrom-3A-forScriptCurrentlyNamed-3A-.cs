acceptableScriptNameFrom: originalString forScriptCurrentlyNamed: currentName
	"Produce an acceptable script name, derived from the current name, for the receiver.  This method will always return a valid script name that will be suitable for use in the given situation, though you might not like its beauty sometimes."

	| aString stemAndSuffix proscribed stem suffix withoutColon currentNumArgs withColon |
	withoutColon _ originalString copyWithoutAll: {$:. $ }.
	(currentName notNil and: [(currentName copyWithout: $:) = withoutColon])
		ifTrue:
			[^ currentName].  "viz. no change; otherwise, the #respondsTo: check gets in the way"

	currentNumArgs _ currentName ifNil: [0] ifNotNil: [currentName numArgs].
	aString _ withoutColon asIdentifier: false.  "get an identifier starting with a lowercase letter"
	stemAndSuffix _ aString stemAndNumericSuffix.
	proscribed _ #(self super thisContext costume costumes dependents #true #false size).

	stem _ stemAndSuffix first.
	suffix _ stemAndSuffix last.
	withoutColon _ aString asSymbol.
	withColon _ (withoutColon, ':') asSymbol.

	[(proscribed includes: withoutColon)
		or: [self respondsTo: withoutColon]
		or: [self respondsTo: withColon]
		or:	[Smalltalk includesKey: withoutColon]
		or: [Smalltalk includesKey: withColon]]
	whileTrue:
		[suffix _ suffix + 1.
		withoutColon _ (stem, suffix printString) asSymbol.
		withColon _ (withoutColon, ':') asSymbol].

	^ currentNumArgs = 0
		ifTrue:
			[withoutColon]
		ifFalse:
			[withColon]