deEmphasizeForDebugger
	"Carefully de-emphasis this window because a debugger is being opened. Care must be taken to avoid invoking potentially buggy window display code that could cause a recursive chain of errors eventually resulting in a virtual machine crash. In particular, do not de-emphasize the subviews."

	self deEmphasizeView.  "de-emphasize this top-level view"
	self uncacheBits.
	Smalltalk garbageCollectMost > 1000000 ifTrue: [
		"if there is enough space, cache current window screen bits"
		self cacheBitsAsIs].
