reportRecursiveMethods
	"Report in transcript all methods that can call themselves directly or indirectly or via a chain of N intermediate methods."

	| visited calls newCalls sel called |
	methods do: [: m |
		visited _ translationDict keys asSet.
		calls _ m allCalls asOrderedCollection.
		5 timesRepeat: [
			newCalls _ Set new: 50.
			[calls isEmpty] whileFalse: [
				sel _ calls removeFirst.
				sel = m selector ifTrue: [
					Transcript show: m selector, ' is recursive'; cr.
				] ifFalse: [
					(visited includes: sel) ifFalse: [
						called _ self methodNamed: sel.
						called = nil ifFalse: [ newCalls addAll: called allCalls ].
					].
					visited add: sel.
				].
			].
			calls _ newCalls asOrderedCollection.
		].
	].