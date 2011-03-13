addMorphNearBack: aMorph
	| bg |
	submorphs last mustBeBackmost ifTrue:
		[bg _ submorphs last.
		bg privateDelete].
	self addMorphBack: aMorph.
	bg ifNotNil: [self addMorphBack: bg]