wantsDroppedMorph: aMorph event: evt
	aMorph willingToBeEmbeddedUponLanding ifFalse: [^ false].
	self visible ifFalse: [^ false].  "will be a call to #hidden again very soon"
	self dragNDropEnabled ifFalse: [^ false].
	(self bounds containsPoint: (self pointFromWorld: evt cursorPoint)) ifFalse: [^ false].
	^ true