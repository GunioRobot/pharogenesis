cursorWrapped: aNumber

	| sz |
	cursor ~= aNumber ifTrue: [
		cursor _ aNumber.
		sz _ data size.
		sz = 0
			ifTrue: [cursor _ 1]
			ifFalse: [
				((cursor >= (sz + 1)) or: [cursor < 0]) ifTrue: [
					cursor _ cursor - ((cursor // sz) * sz)].
				cursor < 1 ifTrue: [cursor _ sz + cursor]].
		"assert: 1 <= cursor < data size + 1"
		hasChanged _ true].
