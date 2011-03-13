returnNode: aNode expression: expr

	| row expMorph sMorph aNoiseString |
	row _ self addRow: #return on: aNode.
	self alansTest1 ifTrue: [
		row setSpecialOuterTestFormat.
		aNoiseString _ ' Reply '.
		sMorph _ self aSimpleStringMorphWith: aNoiseString.
		sMorph 
			emphasis: TextEmphasis bold emphasisCode;
			setProperty: #syntacticallyCorrectContents toValue: '^'.

		row addMorphBack: sMorph.
	] ifFalse: [
		row addToken: '^ ' type: #upArrow on: aNode.
	].
	expMorph _ expr asMorphicSyntaxIn: row.
	self alansTest1 ifTrue: [
		(expMorph hasProperty: #deselectedColor) ifFalse: [expMorph setConditionalPartStyle].
	].
	expr addCommentToMorph: row.
	^row
