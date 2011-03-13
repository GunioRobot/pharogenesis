linesDo: aBlock
	"execute aBlock with each line in this string.  The terminating CR's are not included in what is passed to aBlock"
	| start end |
	start := 1.
	[ start <= self size ] whileTrue: [
		end := self indexOf: Character cr  startingAt: start  ifAbsent: [ self size + 1 ].
		end := end - 1.

		aBlock value: (self copyFrom: start  to: end).
		start := end + 2. ].