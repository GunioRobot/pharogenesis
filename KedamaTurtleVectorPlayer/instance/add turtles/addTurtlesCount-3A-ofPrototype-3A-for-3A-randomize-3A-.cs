addTurtlesCount: count ofPrototype: prototype for: aKedamaWorld randomize: randomizeFlag

	| index array defaultValue newArray oldCount |
	oldCount _ self size.
	info associationsDo: [:assoc |
		index _ info at: assoc key.
		array _ arrays at: index.
		defaultValue _ prototype at: index.
		newArray _ array class new: count.
		newArray atAllPut: defaultValue.
		arrays at: index put: (array, newArray).
	].

	self setInitialValueOf: #who from: oldCount + 1 to: self size for: aKedamaWorld.

	randomizeFlag ifTrue: [
		#(x y heading) do: [:name |
			self setInitialValueOf: name from: oldCount + 1 to: self size for: aKedamaWorld.
		].
	].
	whoTableValid _ false.
