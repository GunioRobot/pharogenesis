testOverlapAnyScriptedPlayer
	"self debug: #testOverlapAnyScriptedPlayer"
	| me friend other sibling |
	me := Morph new assuredPlayer assureUniClass; yourself.
	friend := EllipseMorph new assuredPlayer assureUniClass; yourself.
	sibling := friend getNewClone.
	other := EllipseMorph new assuredPlayer assureUniClass; yourself.
	self getWorld addMorph: me costume;
		 addMorph: friend costume;
		 addMorph: other costume;
		 addMorph: sibling costume.
	"myself"
	self assert: (me overlapsAny: me) not.
	"Same position with sibling"
	me costume position: 0 @ 0.
	friend costume position: 500 @ 0.
	other costume position: 500 @ 0.
	sibling costume position: 0@0.
	self assert: (me overlapsAny: friend).
	"Different position with sibling but same class"
	me costume position: 0 @ 0.
	friend costume position: 500 @ 0.
	sibling costume position: 500@ 0.
	other costume position: 0 @ 0.
	self assert: (me overlapsAny: friend) not