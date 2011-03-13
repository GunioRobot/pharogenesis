newHead
	| m |
	m := HeadMorph new.
	self head: m.
	m openInWorld.
	^ m