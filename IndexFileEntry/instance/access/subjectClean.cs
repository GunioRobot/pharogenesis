subjectClean
	"Returns a clean subject without a Re: "
	| sub |
	sub := self subject asLowercase.
	(sub beginsWith: 're: ')
	ifTrue: [^sub copyFrom: 5 to: (sub size)].
	^sub