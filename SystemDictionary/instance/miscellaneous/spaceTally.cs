spaceTally
	"Answer a collection of tuples representing the memory space (in bytes) consumed by the code and instances of each class in the system. The tuples have the form:
	<class> <code size> <instance count> <space for instances>
Code sizes do not currently report memory consumed by class variables. The arrays used to record these results consume a relatively insignificant amount of space."
	"(Smalltalk spaceTally asSortedCollection: [:a :b | a last > b last]) asArray"

	| results entry c |
	"pre-allocate array of entries for results"
	results _ OrderedCollection new: self size.
	self do: [:cl |
		(cl isKindOf: Class) ifTrue: [
			entry _ Array new: 4.
			entry at: 1 put: cl.
			results add: entry]].
	results _ results asArray.

	Smalltalk garbageCollect.
	1 to: results size do: [:i |
		entry _ results at: i.
		c _ entry at: 1.
		entry at: 2 put: c spaceUsed.
		entry at: 3 put: c instanceCount.
		entry at: 4 put: (self spaceForInstancesOf: c).
		Smalltalk garbageCollectMost].
	^ results
