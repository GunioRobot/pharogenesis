wrapFlag
	"Answer the wrap flag on the text morph."
	
	^(self textMorph ifNil: [self setText: '']) wrapFlag