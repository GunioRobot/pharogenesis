primesUpTo: max
	"Return a list of prime integers up to the given integer."
	"Integer primesUpTo: 100"

	| out limit flags prime k |
	out _ OrderedCollection new.
	limit _ max asInteger - 1.
	flags _ (Array new: limit) atAllPut: true.
	1 to: limit do: [:i |
		(flags at: i) ifTrue: [
			prime _ i + 1.
			k _ i + prime.
			[k <= limit] whileTrue: [
				flags at: k put: false.
				k _ k + prime].
			out add: prime]].
	^ out asArray
