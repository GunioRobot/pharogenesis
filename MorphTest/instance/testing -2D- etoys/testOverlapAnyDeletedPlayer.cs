testOverlapAnyDeletedPlayer
	"self debug: #testOverlapAnyDeletedPlayer"
	| me friend sibling |
	me := Morph new assuredPlayer assureUniClass; yourself.
	friend := EllipseMorph new assuredPlayer assureUniClass; yourself.
	sibling := friend getNewClone.
	sibling costume delete.
	self getWorld addMorph: me costume.
	"Same position but deleted"
	me costume position: 0 @ 0.
	friend costume position: 0 @ 0.
	sibling costume position: 0 @ 0.
	self assert: (me overlapsAny: friend) not.
	self assert: (me overlapsAny: sibling) not