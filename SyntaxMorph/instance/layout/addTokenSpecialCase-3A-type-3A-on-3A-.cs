addTokenSpecialCase: aString type: aColorOrSymbol on: aNode

	| sMorph modifiedString noiseWord col |

	noiseWord _ nil.
	sMorph _ self addString: aString special: false.
	(aColorOrSymbol == #keyword2) ifTrue: [
		modifiedString _ aString = 'if:' ifTrue: ['Test'] ifFalse: ['Yes'].
		sMorph 
			font: (self fontToUseForSpecialWord: modifiedString); 
			setProperty: #syntacticallyCorrectContents toValue: aString;
			contents: modifiedString.
	].

	col _ (self addRow: aColorOrSymbol on: aNode) layoutInset: 1.
	noiseWord ifNotNil: [
		col 
			addMorphBack: (self noiseStringMorph: noiseWord);
			addMorphBack: (self transparentSpacerOfSize: 3@1)
	].
	col addMorphBack: sMorph.
	^col