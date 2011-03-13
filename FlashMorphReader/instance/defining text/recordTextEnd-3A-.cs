recordTextEnd: id
	textMorph submorphs isEmpty ifFalse:[
		textMorph allMorphsDo:[:m| m color: textMorph color].
		textMorph transform: nil.
		textMorph id: id.
		textMorph stepTime: stepTime.
		textMorph lockChildren.
		shapes at: id put: textMorph].
	self doLog ifTrue:[log := Transcript].