setEdge: anEdge
	| changedOrientation |
	changedOrientation _ nil.
	self orientation == #vertical
			ifTrue:
				[(#(top bottom) includes: anEdge) ifTrue:
					[changedOrientation _ #horizontal]]
			ifFalse:
				[(#(top bottom) includes: anEdge) ifFalse:
					[changedOrientation _ #vertical]].
	changedOrientation ifNotNil:
		[^ self inform:
'SORRY -- this sort of switch from horizontal to vertical
or vice-versa is not yet permitted.  For now, to achieve
the desired effect, create a new flap and copy over
the elements you want.'].

	self isCurrentlyTextual ifTrue:
		[changedOrientation ifNotNil:
			[self assumeString: (submorphs first contents copyWithout: Character cr) font:  Preferences standardFlapFont orientation: changedOrientation color: self color]].

	self edgeToAdhereTo: anEdge.
	changedOrientation ifNotNil:
		[self transposeParts].
	referent isInWorld ifTrue: [self positionReferent].
	self adjustPositionVisAVisFlap