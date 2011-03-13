bestInstallPath
	"Using some heuristics we suggest the best path:
		- No conflicts
		- Fewest releases
		- If same packages, the newest releases"

	| paths min points point package sc |
	paths := self installPathsWithoutConflicts.
	paths size = 1 ifTrue: [^paths first].
	min := paths inject: 999 into: [:mi :p | p size < mi ifTrue: [p size] ifFalse: [mi]].
	paths := paths select: [:p | p size = min].
	paths size = 1 ifTrue: [^paths first].
	"Try to pick the one with newest releases"
	points := Dictionary new.
	paths do: [:p |
		point := 0.
		p do: [:r |
			package := r package.
			paths do: [:p2 |
				p2 == p ifFalse: [
					(p2 anySatisfy: [:r2 |
						(r2 package == package) and: [r newerThan: r2]])
							ifTrue:[point := point + 1]]]].
		points at: p put: point].
	points isEmpty ifTrue: [^nil].
	sc := points associations asSortedCollection: [:a :b | a value >= b value].
	^ sc first key