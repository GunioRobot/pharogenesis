unreachableMethods
	"Return a collection of methods that are never invoked."

	| sent out |
	sent _ Set new.
	methods do: [ :m |
		sent addAll: m allCalls.
	].

	out _ OrderedCollection new.
	methods keys do: [ :sel |
		(sent includes: sel) ifFalse: [ out add: sel ].
	].
	^ out