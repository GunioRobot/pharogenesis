xxxfixLayout
	| trans |
	trans _ self myTransformation.
	trans ifNil:[^super fixLayout].
	trans bounds: self innerBounds.

