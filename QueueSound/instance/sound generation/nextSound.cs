nextSound
	| answer |
	sounds isEmpty ifTrue: [^ nil].
	answer _ sounds next.
	answer reset.
	^ answer