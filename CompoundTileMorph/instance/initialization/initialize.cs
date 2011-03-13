initialize

	| r |
	super initialize.
	self color: Color orange muchLighter.
	self borderWidth: 1.
	self layoutInset: 2.
	self listDirection: #topToBottom.
	self hResizing: #shrinkWrap; vResizing: #shrinkWrap.

	r _ AlignmentMorph newRow color: color; layoutInset: 0.
	r setProperty: #demandsBoolean toValue: true.
	r addMorphBack: (Morph new color: color; extent: 2@5).  "spacer"
	r addMorphBack: (StringMorph new contents: 'Test').
	r addMorphBack: (Morph new color: color; extent: 5@5).  "spacer"
	r addMorphBack: (testPart _ BooleanScriptEditor new borderWidth: 0; layoutInset: 1).
	testPart color: Color transparent.
	self addMorphBack: r.

	r _ AlignmentMorph newRow color: color; layoutInset: 0.
	r addMorphBack: (Morph new color: color; extent: 30@5).  "spacer"
	r addMorphBack: (StringMorph new contents: 'Yes').
	r addMorphBack: (Morph new color: color; extent: 5@5).  "spacer"
	r addMorphBack: (yesPart _ ScriptEditorMorph new borderWidth: 0; layoutInset: 2).
	yesPart color: Color transparent.
	self addMorphBack: r.

	r _ AlignmentMorph newRow color: color; layoutInset: 0.
	r addMorphBack: (Morph new color: color; extent: 35@5).  "spacer"
	r addMorphBack: (StringMorph new contents: 'No').
	r addMorphBack: (Morph new color: color; extent: 5@5).  "spacer"
	r addMorphBack: (noPart _ ScriptEditorMorph new borderWidth: 0; layoutInset: 2).
	noPart color: Color transparent.
	self addMorphBack: r.

	self extent: 5@5.  "will grow to fit"
