mouseOverList: evt
	"Returns a list consisting of the topmost unlocked morph in the
	innermost frame (pasteUp), and all of its containers in that frame."

	"This new version treats halos as independent so as not to mask
	mouseovers of morphs beneath an active halo."

	| top |
	top _ self mouseOverList: evt rank: 1.
	(top isEmpty or: [(top last isKindOf: HaloMorph) not])
		ifTrue: [^ top]
		ifFalse: [^ top , (self mouseOverList: evt rank: 2)]