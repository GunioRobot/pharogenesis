testNormalize

	"Check normalization and conversion to/from SmallInts"

	self should: [(SmallInteger maxVal + 1 - 1) == SmallInteger maxVal].
	self should: [(SmallInteger maxVal + 3 - 6) == (SmallInteger maxVal-3)].
	self should: [(SmallInteger minVal - 1 + 1) == SmallInteger minVal].
	self should: [(SmallInteger minVal - 3 + 6) == (SmallInteger minVal+3)].