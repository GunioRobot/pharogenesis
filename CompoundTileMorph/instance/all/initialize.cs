initialize

	| r |
	super initialize.
	self color: Color orange muchLighter.
	self borderWidth: 1.
	self inset: 2.
	self orientation: #vertical.

	r _ AlignmentMorph newRow color: color; inset: 0.
	r setProperty: #demandsBoolean toValue: true.
	r addMorphBack: (Morph new color: color; extent: 2@5).  "spacer"
	r addMorphBack: (StringMorph new contents: 'Test').
	r addMorphBack: (Morph new color: color; extent: 5@5).  "spacer"
	r addMorphBack: (testPart _ BooleanScriptEditor new borderWidth: 0; inset: 1).
	testPart color: Color transparent.
	self addMorphBack: r.

	r _ AlignmentMorph newRow color: color; inset: 0.
	r addMorphBack: (Morph new color: color; extent: 30@5).  "spacer"
	r addMorphBack: (StringMorph new contents: 'Yes').
	r addMorphBack: (Morph new color: color; extent: 5@5).  "spacer"
	r addMorphBack: (yesPart _ ScriptEditorMorph new borderWidth: 0; inset: 2).
	yesPart color: Color transparent.
	self addMorphBack: r.

	r _ AlignmentMorph newRow color: color; inset: 0.
	r addMorphBack: (Morph new color: color; extent: 35@5).  "spacer"
	r addMorphBack: (StringMorph new contents: 'No').
	r addMorphBack: (Morph new color: color; extent: 5@5).  "spacer"
	r addMorphBack: (noPart _ ScriptEditorMorph new borderWidth: 0; inset: 2).
	noPart color: Color transparent.
	self addMorphBack: r.

	self extent: 5@5.  "will grow to fit"
