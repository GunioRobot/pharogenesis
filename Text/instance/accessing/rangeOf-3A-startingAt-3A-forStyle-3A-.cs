rangeOf: attribute startingAt: index forStyle: aStyle
	"This is stupid, slow code, but it works"
	| start stop |
	start _ index.
	[start > 1 and: [(self attributesAt: (start - 1) forStyle: aStyle) includes: attribute]]
		whileTrue: [start _ start - 1].
	stop _ index-1.
	[stop < self size and: [(self attributesAt: (stop + 1) forStyle: aStyle) includes: attribute]]
		whileTrue: [stop _ stop + 1].
	^ start to: stop