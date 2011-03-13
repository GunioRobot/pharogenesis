wrapFlag: aBoolean
	"Set the wrap flag on the text morph."
	
	self textMorph ifNil: [self setText: ''].
	self textMorph wrapFlag: aBoolean