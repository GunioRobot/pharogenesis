permuteData
	| i end a b tmp |
	self var: #tmp declareC: 'float tmp'.
	i _ 0.
	end _ permTableSize.
	[i < end] whileTrue:
		[a _ (permTable at: i) - 1.
		b _ (permTable at: i+1) - 1.

		(a < realDataSize and:[b < realDataSize]) ifFalse:[^interpreterProxy success: false].

		tmp _ realData at: a.
		realData at: a put: (realData at: b).
		realData at: b put: tmp.

		tmp _ imagData at: a.
		imagData at: a put: (imagData at: b).
		imagData at: b put: tmp.

		i _ i + 2]