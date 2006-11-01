testWindowCloseAction
	"This can only work if we're actually run in MVC"
	World isNil ifTrue: [super testWindowCloseAction]