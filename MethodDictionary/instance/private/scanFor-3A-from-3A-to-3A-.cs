scanFor: key from: start to: finish
	"Scan the key array for the first slot containing either a nil (indicating an empty slot) or an element that matches the key. Answer the index of that slot or zero if no slot is found within the given range of indices."

	| element |
	"this speeds up a common case: key is in the first slot"
	((element _ self basicAt: start) == nil or: [element == key])
		ifTrue: [ ^ start ].

	start + 1 to: finish do: [ :index |
		((element _ self basicAt: index) == nil or: [element == key])
			ifTrue: [ ^ index ].
	].
	^ 0
