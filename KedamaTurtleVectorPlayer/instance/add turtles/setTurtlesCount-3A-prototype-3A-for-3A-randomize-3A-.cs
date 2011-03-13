setTurtlesCount: count prototype: prototype for: aKedamaWorld randomize: rondomizeFlag

	| anInteger array |
	anInteger _ count.
	count < 0 ifTrue: [anInteger _ 0].

	self size > anInteger ifTrue: [
		info associationsDo: [:assoc |
			array _ (arrays at: assoc value).
			array _ array copyFrom: 1 to: anInteger.
			arrays at: assoc value put: array.
		].
		turtleMapValid _ false.
		whoTableValid _ false.
	].

	self size < anInteger ifTrue: [
		self addTurtlesCount: (anInteger - self size) ofPrototype: prototype for: aKedamaWorld randomize: rondomizeFlag.
		turtleMapValid _ false.
		whoTableValid _ false.

	].


