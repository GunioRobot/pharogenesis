setLiteralTo: anObject width: w
	| soundChoices index |
	self flag: #deferrred.  "This is still in process, and until it's worked through, #sound as a data type for user-added slots will continue to be disallowed"

	soundChoices _ #('silence').  "default, if no SampledSound class"
	Smalltalk at: #SampledSound ifPresent:
		[:sampledSound | soundChoices _ sampledSound soundNames].
	index _ soundChoices indexOf: anObject.
	self setLiteral: (soundChoices atWrap: index)