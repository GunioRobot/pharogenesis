keywords
	"Answer an array of the keywords that compose the receiver."

	| answer size last |
	answer _ OrderedCollection new.
	size _ self size.
	last _ 0.
	1 to: size do:
		[:index |
		(self at: index) == $: ifTrue:
			[answer add: (self copyFrom: last + 1 to: index).
			last _ index]].
	last = size ifFalse: [answer add: (self copyFrom: last + 1 to: size)].
	^ answer asArray