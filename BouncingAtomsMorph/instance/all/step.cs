step
	"Bounce those atoms!"

	| r |
	r _ bounds origin corner: (bounds corner - (8@8)).
	self submorphsDo: [ :m |
		(m isMemberOf: AtomMorph) ifTrue: [m bounceIn: r]].
	transmitInfection ifTrue: [self transmitInfection].
