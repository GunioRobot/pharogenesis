recognize: dispatcherArray
	"Answer first item found"

	| first |
	first := nil.
	self recognize: dispatcherArray do: [:item |
		first == nil ifTrue: [first := item]].
	^first