methodsThatCanInvoke: aSelectorList
	"Return a set of methods that can invoke one of the given selectors, either directly or via a sequence of intermediate methods."

	| out todo sel mSelector |
	out _ Set new.
	todo _ aSelectorList copy asOrderedCollection.
	[todo isEmpty] whileFalse: [
		sel _ todo removeFirst.
		out add: sel.
		methods do: [ :m |
			(m allCalls includes: sel) ifTrue: [
				mSelector _ m selector.
				((out includes: mSelector) or:
				 [todo includes: mSelector]) ifFalse: [
					todo add: mSelector.
				].
			].
		].
	].
	^ out
	