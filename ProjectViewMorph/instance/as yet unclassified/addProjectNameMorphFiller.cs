addProjectNameMorphFiller

	| m |

	self removeAllMorphs.
	m _ AlignmentMorph newRow color: Color transparent.
	self addMorphBack: m.
	m
		on: #mouseDown send: #editTheName: to: self;
		on: #mouseUp send: #yourself to: self.
	self updateNamePosition.

