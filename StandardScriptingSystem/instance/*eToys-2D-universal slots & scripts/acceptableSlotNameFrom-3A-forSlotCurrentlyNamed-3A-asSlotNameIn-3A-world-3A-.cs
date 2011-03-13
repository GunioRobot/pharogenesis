acceptableSlotNameFrom: originalString forSlotCurrentlyNamed: currentName asSlotNameIn: aPlayer world: aWorld
	"Produce an acceptable slot name, derived from the current name, for aPlayer.  This method will always return a valid slot name that will be suitable for use in the given situation, though you might not like its beauty sometimes."

	| aString stemAndSuffix proscribed stem suffix putative |
	aString := originalString asIdentifier: false.  "get an identifier not lowercase"
	stemAndSuffix := aString stemAndNumericSuffix.
	proscribed := #(self super thisContext costume costumes dependents #true #false size), aPlayer class allInstVarNames.

	stem := stemAndSuffix first.
	suffix := stemAndSuffix last.
	putative := aString asSymbol.
	
	[(putative ~~ currentName) and: [(proscribed includes: putative)
		or:	[(aPlayer respondsTo: putative)
		or:	[Smalltalk includesKey: putative]]]]
	whileTrue:
		[suffix := suffix + 1.
		putative := (stem, suffix printString) asSymbol].
	^ putative