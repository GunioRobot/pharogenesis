testOverlapAnyUnscriptedPlayer
	"self debug: #testOverlapAnyUnscriptedPlayer"
	| p1 p2 p3 |
	p1 := Morph new assuredPlayer.
	p2 := EllipseMorph new assuredPlayer.
	p3 := EllipseMorph new assuredPlayer.
	self getWorld addMorph: p1 costume;
		 addMorph: p2 costume;
		 addMorph: p3 costume.
	"Same class, same position"
	p1 costume position: 0 @ 0.
	p2 costume position: 500 @ 0.
	p3 costume position: 0 @ 0.
	self
		assert: (p1 overlapsAny: p2).
	"Same class, different position"
	p1 costume position: 0 @ 0.
	p2 costume position: 1000 @ 0.
	p3 costume position: 500 @ 0.
	self assert: (p1 overlapsAny: p2) not.
