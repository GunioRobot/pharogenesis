designationsExplainer
	"Answer a morph that contains designation explanation"

	| aMorph aSwatch aTextMorph |
	aMorph _ AlignmentMorph newColumn color: Color black; layoutInset: 1.
	#((green		
'Shared items on
Background.
Exact same item
shared by every card')
	(orange
'Data items on
Background
Each card has its
own data')
	(red
'Instance-specific
items
unique
to this card')) do:

	[:aPair |
		aSwatch _ AlignmentMorph new extent: 132 @80; color: (Color perform: aPair first); lock.
		aSwatch hResizing: #rigid; vResizing: #rigid; layoutInset: 0.
		aSwatch borderColor: Color black.
		aTextMorph _ TextMorph new string: aPair second fontName: 'ComicBold' size: 18.
		aTextMorph width: 130.
		aTextMorph centered.
		aSwatch addMorphBack: aTextMorph.
		aMorph addMorphBack: aSwatch].

	^ aMorph

	"StackMorph designationsExplainer openInHand"
