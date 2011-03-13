testSaltypickle
	gofer saltypickle: 'GraphViz'.
	self assert: gofer repository locationWithTrailingSlash = 'http://squeak.saltypickle.com/GraphViz/'