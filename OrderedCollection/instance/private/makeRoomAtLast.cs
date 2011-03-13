makeRoomAtLast
	| newLast delta |
	newLast := self size.
	array size - self size = 0 ifTrue: [self grow].
	(delta := firstIndex - 1) = 0 ifTrue: [^ self].
	"we might be here under false premises or grow did the job for us"
	1 to: newLast do:
		[:index |
		array at: index put: (array at: index + delta).
		array at: index + delta put: nil].
	firstIndex := 1.
	lastIndex := newLast