copyVariation: move 
	| av mv count |
	count := 0.
	av := variations at: ply + 1.
	ply < 9 
		ifTrue: 
			[mv := variations at: ply + 2.
			count := mv first.
			av 
				replaceFrom: 3
				to: count + 2
				with: mv
				startingAt: 2].
	av at: 1 put: count + 1.
	av at: 2 put: move encodedMove