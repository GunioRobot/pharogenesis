scanFor: anObject
	"Same as super except change = to ==, and hash to identityHash"

	| element start finish |
	finish := array size.
	start := (anObject identityHash \\ finish) + 1.
	

	"Search from (hash mod size) to the end."
	start to: finish do:
		[:index | ((element := array at: index) == nil or: [(keyBlock value: element) == anObject])
			ifTrue: [^ index ]].

	"Search from 1 to where we started."
	1 to: start-1 do:
		[:index | ((element := array at: index) == nil or: [(keyBlock value: element) == anObject])
			ifTrue: [^ index ]].

	^ 0  "No match AND no empty slot"