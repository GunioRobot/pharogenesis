asPacked

	self inject: 0 into: [:pack :next | pack _ pack * 16r100000000 + next asInteger].
