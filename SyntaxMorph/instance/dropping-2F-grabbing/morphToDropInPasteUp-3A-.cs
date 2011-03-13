morphToDropInPasteUp: aPasteUp
	"If property #beScript is true, create a scriptor around me."

	| actualObject itsSelector aScriptor adjustment handy tw blk |
	self flag: #noteToTed.  "I changed PhraseTileMorph's version of this method to eliminate the flagshipInstance annoyance, and the below needs to be changed accordingly -- look at my method and notice diffs.  Besides eliminating the flagshipInstance test, one needs to be sure that the thing dropped is adjusted to reflect which instance of the uniclass is at hand.  sw 1/19/2001 02:30"

	(self valueOfProperty: #beScript ifAbsent: [false]) ifFalse: [^ self].
	self removeProperty: #beScript.

	(actualObject _ self actualObject) ifNil: [^ self].
	actualObject assureUniClass.

	itsSelector _ self userScriptSelector.
	aScriptor _ itsSelector isEmptyOrNil
		ifFalse:
			[adjustment _ 0@0.
			actualObject scriptEditorFor: itsSelector]
		ifTrue:
			["It's a system-defined selector; construct an anonymous scriptor around it"
			adjustment _ 60 @ 20.
			actualObject newScriptorAround: self].

	handy _ aPasteUp primaryHand.
	aScriptor ifNotNil: [
		aScriptor position: handy position - adjustment.
		aPasteUp addMorphFront: aScriptor.	"do this early so can find World"
		(tw _ aScriptor findA: TwoWayScrollPane) ifNil: [
			aScriptor useNewTiles.
			itsSelector ifNil: ["blank script"
				tw _ aScriptor findA: TwoWayScrollPane.
				blk _ tw scroller firstSubmorph "MethodNode" lastSubmorph "BlockNode".
				blk addMorphFront: self.
				"self position: self topLeft + (7@14)"]]].
	aScriptor showSourceInScriptor.  "**This destroys most of the work done before**"
	aScriptor hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		cellPositioning: #topLeft.
	(aScriptor isKindOf: ScriptEditorMorph) ifTrue:
		[aScriptor playerScripted expungeEmptyUnRenamedScripts].
	^ aScriptor ifNil: [self]
