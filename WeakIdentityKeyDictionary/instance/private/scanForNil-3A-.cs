scanForNil: anObject
	"Private. Scan the key array for the first slot containing nil (indicating an empty slot). Answer the index of that slot."
	| start finish hash |
	finish _ array size.
	finish > 4096
		ifTrue: [hash _ anObject identityHash * (finish // 4096)]
		ifFalse: [hash _ anObject identityHash].
	start _ (hash \\ array size) + 1.

	"Search from (hash mod size) to the end."
	start to: finish do:
		[:index | (array at: index) == nil ifTrue: [^ index ]].

	"Search from 1 to where we started."
	1 to: start-1 do:
		[:index | (array at: index) == nil ifTrue: [^ index ]].

	^ 0  "No match AND no empty slot"