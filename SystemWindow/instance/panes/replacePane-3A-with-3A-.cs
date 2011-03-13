replacePane: oldPane with: newPane

	newPane
		position: oldPane position;
		extent: oldPane extent.
	oldPane visible: false; lock: true; extent: 10@10.
	newPane visible: true; lock: false.
	(submorphs includes: newPane) ifFalse: [self addMorph: newPane].
	paneMorphs _ paneMorphs collect: [ :each |
		each == oldPane ifTrue: [newPane] ifFalse: [each]
	].
	self changed.

