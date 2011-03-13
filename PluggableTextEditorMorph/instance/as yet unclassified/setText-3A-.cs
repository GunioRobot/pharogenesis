setText: aText
	"Set the auto accept on the text morph."
	
	self textMorph ifNil: [
		super setText: aText.
		self textMorph
			autoAccept: self autoAccept;
			selectionColor: self selectionColor.
		^self].
	^super setText: aText