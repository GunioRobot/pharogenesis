assignmentNode: aNode variable: variable value: value

	| row v expMorph |

	row _ self addRow: #assignment on: aNode.
	v _ variable asMorphicSyntaxIn: row.
	self alansTest1 ifTrue: [v setConditionalPartStyle; layoutInset: 2].
	row addToken: ' _ ' type: #assignmentArrow on: aNode.
	expMorph _ value asMorphicSyntaxIn: row.
	self alansTest1 ifTrue: [
		row setSpecialOuterTestFormat.
		(expMorph hasProperty: #deselectedColor) ifFalse: [expMorph setConditionalPartStyle].
	].
	^row
