stretch: aNumber
	self do: [ :each | each stretch: aNumber].
	self timedEvents do: [ :each | each key: (each key * aNumber) rounded]