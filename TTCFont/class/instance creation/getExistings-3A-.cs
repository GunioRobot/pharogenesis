getExistings: fontArray

	| result em |
	result _ OrderedCollection new.
	result add: fontArray.
	1 to: 3 do: [:i |
		em _ (fontArray collect: [:f | f emphasized: i]).
		(em at: 1) ~= (fontArray at: 1) ifTrue: [
			result add: em.
		].
	].
	^ result asArray.
