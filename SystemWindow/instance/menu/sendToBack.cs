sendToBack
	| aWorld nextWindow |
	aWorld _ self world.
	nextWindow _ aWorld submorphs detect:
		[:m | (m isKindOf: SystemWindow) and:  [m ~~ self]] ifNone: [^ self].
	nextWindow activate.
	aWorld addMorphNearBack: self
