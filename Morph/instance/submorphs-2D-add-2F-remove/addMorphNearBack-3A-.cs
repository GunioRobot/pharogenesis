addMorphNearBack: aMorph
	| bg |
	(submorphs size > 0 and: [submorphs last mustBeBackmost]) ifTrue:
		[bg _ submorphs last.
		bg privateDelete].
	self addMorphBack: aMorph.
	bg ifNotNil: [self addMorphBack: bg]