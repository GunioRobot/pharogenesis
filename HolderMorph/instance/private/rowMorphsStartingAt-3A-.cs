rowMorphsStartingAt: startIndex
	"Return a collection of morphs for a row starting at the given index. Put at least one morph into the row, even if it sticks out."

	| mList nextX lastIndex m |
	mList _ OrderedCollection new.
	nextX _ bounds left + borderWidth + padding.
	lastIndex _ submorphs size.
	startIndex to: lastIndex do: [:i |
		m _ submorphs at: i.
		nextX _ nextX + m fullBounds width + padding.
		nextX > bounds right ifTrue: [
			mList isEmpty ifTrue: [mList add: m].
			^ mList].
		mList add: m].
	^ mList
