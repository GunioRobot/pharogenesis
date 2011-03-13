acceptableScriptNameFrom: originalString forScriptCurrentlyNamed: currentName asScriptNameIn: aPlayer world: aWorld
	"Produce an acceptable script name, derived from the current name, for aPlayer.  This method will always return a valid script name that will be suitable for use in the given situation, though you might not like its beauty sometimes."

	| aString stemAndSuffix proscribed stem suffix putative |
	aString _ originalString asIdentifier: false.  "get an identifier not lowercase"
	stemAndSuffix _ aString stemAndNumericSuffix.
	proscribed _ #(self super thisContext costume costumes dependents true false size).

	stem _ stemAndSuffix first.
	suffix _ stemAndSuffix last.
	putative _ aString asSymbol.

	[(putative ~~ currentName) and: [(proscribed includes: putative)
		or:	[(aPlayer class tileScriptNames includes: putative)
		or: [(aPlayer respondsTo: putative)
		or: [(SystemSlotDictionary includesKey: putative)
		or: [(ReservedScriptNames includes: putative)
		or:	[Smalltalk includesKey: putative]]]]]]]
	whileTrue:
		[suffix _ suffix + 1.
		putative _ (stem, suffix printString) asSymbol].
	^ putative