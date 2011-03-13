indexOf: who

	| whoArray |
	whoTableValid ifTrue: [^ whoTable at: (who - whoTableBase)].

	whoArray _ arrays at: 1.

	whoArray size = 0 ifTrue: [^ 0].

	whoTableBase _ whoArray first - 1.
	whoTable _ WordArray new: whoArray last - whoTableBase.
	1 to: whoArray size do: [:w |
		whoTable at: (whoArray at: w) - whoTableBase put: w.
	].
	whoTableValid _ true.

	^ whoTable at: (who - whoTableBase).

