makePageControls

	| b c r |
	b _ SimpleButtonMorph new target: self; borderColor: Color black.
	c _ AlignmentMorph newColumn.
	c color: b color; borderWidth: 0; inset: 0.
	c hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.

	r _ AlignmentMorph newRow.
	r color: b color; borderWidth: 0; inset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r addMorphBack: (b fullCopy label: '<-';			actionSelector: #previousPage).
	r addMorphBack: (b fullCopy label: 'Insert';		actionSelector: #insertPage).
	r addMorphBack: (b fullCopy label: 'Delete';		actionSelector: #deletePage).
	r addMorphBack: (b fullCopy label: 'Text';		actionSelector: #newTextMorph).
	r addMorphBack: (b fullCopy label: '->';			actionSelector: #nextPage).
	c addMorphBack: r.

	r _ r copy removeAllMorphs.
	r addMorphBack: (b fullCopy label: 'Bookmark';	actionSelector: #bookmarkForThisPage).
	r addMorphBack: (b fullCopy label: 'Save';		actionSelector: #saveBookToFile).
	c addMorphBack: r.
	
	^ c
