outer
	"Evaluate the enclosing exception action and return to here instead of signal if it resumes (see #resumeUnchecked:)."

	| prevOuterContext |
	self isResumable ifTrue: [
		prevOuterContext _ outerContext.
		outerContext _ thisContext contextTag.
	].
	self pass.
