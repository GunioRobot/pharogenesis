findID: id in: dispatcher
	"Return index of id in dispatcher, nil if not found"

	1 to: dispatcher size do: [:i |
		((dispatcher at: i) at: 1) = id ifTrue: [^i]].
	^nil