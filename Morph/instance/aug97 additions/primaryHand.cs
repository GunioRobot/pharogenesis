primaryHand
	| aWorld |
	(aWorld _ self world) ifNil: [^ nil].
	^ aWorld hands first 