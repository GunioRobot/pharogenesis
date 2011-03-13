textPlusMenuFor: aMorph

	| menu |
	menu _ MenuMorph new.
	menu 
		add: 'Link to text selection' 
		target: [self addAlansAnchorFor: aMorph] fixTemps
		selector: #value;

		add: 'Unlink from text selection' 
		target: [self removeAlansAnchorFor: aMorph] fixTemps
		selector: #value;

		add: 'Delete' 
		target: [
			self removeAlansAnchorFor: aMorph.
			aMorph delete.
		] fixTemps
		selector: #value.
	^menu
