linesDo: aBlock
	"execute aBlock with each line in this string.  The terminating CR's are not included in what is passed to aBlock"
	| start end |
	start _ 1.
	[ start <= self size ] whileTrue: [
		end _ self indexOf: Character cr  startingAt: start  ifAbsent: [ self size + 1 ].
		end _ end - 1.

		aBlock value: (self copyFrom: start  to: end).
		start _ end + 2. ].