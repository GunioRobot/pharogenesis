nearestIDFor: aNumber

	| whoArray last next smaller bigger |
	whoArray _ turtles arrays first.
	whoArray isEmpty ifTrue: [^ nil].
	aNumber < whoArray first ifTrue: [^ whoArray first].

	last _ whoArray at: 1.
	2 to: whoArray size do: [:i |
		(last <= aNumber and: [aNumber < (next _ whoArray at: i)]) ifTrue: [
			smaller _ last.
			bigger _ next.
			(smaller - aNumber) abs <= (bigger - aNumber) abs ifTrue: [^ smaller] ifFalse: [^ bigger].
		].
		last _ next.
	].
	^ last.
