testOverlapAny
	"self debug: #testOverlapAny"
	| p1 p2 |
	p1 _ Morph new assuredPlayer.
	p2 _ EllipseMorph new assuredPlayer.
	"Same position"
	p1 costume position: 0@0.
	p2 costume position: 0@0.
	self assert: (p1 overlapsAny: p2).
	"Different position"
	p1 costume position: 0@0.
	p2 costume position: 500@0.
	self assert: (p1 overlapsAny: p2) not.