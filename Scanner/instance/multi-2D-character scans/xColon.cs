xColon		"Allow := for assignment by converting to #_ "
	aheadChar = $= ifTrue:
		[self step.
		tokenType _ #leftArrow.
		self step.
		^ token _ #_].
	"Otherwise, just do what normal scan of colon would do"
	tokenType _ #colon.
	^ token _ self step asSymbol