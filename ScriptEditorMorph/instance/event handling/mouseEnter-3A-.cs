mouseEnter: evt
	| hand tile |

	self flag: #bob.		"needed renderedMorph due to transformations"
	hand _ evt hand.
	hand submorphs size = 1 ifFalse: [^self].
	tile _ hand firstSubmorph renderedMorph.
	(self wantsDroppedMorph: tile event: evt) ifFalse: [^self].
	handWithTile _ hand.
	self startSteppingSelector: #trackDropZones.