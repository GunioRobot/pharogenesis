toggleSyntaxMorph
"
	syntaxMorph ifNil:
		[syntaxMorph _ self createSyntaxMorph inAScrollPane.
		syntaxMorph color: Color paleOrange].
	standardTextMorph visible ifTrue: [
		standardTextMorph owner replacePane: standardTextMorph with: syntaxMorph.
		syntaxMorph scroller firstSubmorph update: #contentsSelection.
	] ifFalse: [
		syntaxMorph owner replacePane: syntaxMorph with: standardTextMorph.
	].
"
