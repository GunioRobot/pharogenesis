addToken: aString type: aColorOrSymbol on: aNode

	| sMorph modifiedString noiseWord row |

	row _ (self addRow: aColorOrSymbol on: aNode) layoutInset: 1.
	self alansTest1 ifFalse: [
		sMorph _ self addString: aString special: false.
		row addMorphBack: sMorph.
		^row
	].

	noiseWord _ [ :w |
		w ifNotNil: [
			row 
				addMorphBack: (self noiseStringMorph: w);
				addMorphBack: (self tokenVerticalSeparator)
		].
	].
	(self shouldBeBrokenIntoWords: aColorOrSymbol) ifTrue: [
		modifiedString _ self substituteKeywordFor: aString.
		sMorph _ self addString: modifiedString special: (aColorOrSymbol ~= #assignmentArrow).
			"(#(unary keywordGetz keywordSetter unaryGetter) includes: aColorOrSymbol)"
		modifiedString = aString ifFalse: [
			sMorph setProperty: #syntacticallyCorrectContents toValue: aString].
		sMorph setProperty: #syntacticReformatting toValue: aColorOrSymbol;
			contents: modifiedString.
	] ifFalse: [
		sMorph _ self addString: (modifiedString _ aString) special: false.
	].
	(#(keyword2 upArrow) includes: aColorOrSymbol) ifTrue: [
		sMorph 
			font: (self fontToUseForSpecialWord: modifiedString).
	].
	(#(keyword2 unary assignmentArrow methodHeader1 methodHeader2) includes: aColorOrSymbol) ifTrue: [
		sMorph emphasis: 1.
	].
	aColorOrSymbol == #blockarg1 ifTrue: [
	].
	(aColorOrSymbol == #variable or: [aColorOrSymbol == #tempVariable]) ifTrue: [
		aString = 'self' ifTrue: [
			sMorph setProperty: #wordyVariantOfSelf toValue: true.
		].
		noiseWord value: (self noiseWordBeforeVariableNode: aNode string: aString).
	].

	row addMorphBack: sMorph.
	^row