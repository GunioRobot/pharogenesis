selectedSymbol
	"Return the currently selected symbol, or nil if none.  If the selection involves a method send, return the relevent selector.  If the selection is a class name, return that. 1/15/96 sw.
	2/29/96 sw: strip crs before lookup"

	| aString |
	startBlock = stopBlock ifTrue: [^ nil].
	aString _ self selection string copyWithout: Character cr.
	aString size == 0 ifTrue: [^ nil].
	Symbol hasInterned: aString  ifTrue: [:sym | ^ sym].

	^ nil