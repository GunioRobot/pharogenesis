testPermutationsDo

	| i oc |
	i _ (1.234 to: 4.234).
	oc _ OrderedCollection new.
	i permutationsDo: [:e | oc add: e].
	self assert: (oc size == i size factorial)