addTurtleDemon: aSelector
	"Add the given selector to the list of selectors sent to every turtle on every step."

	turtleDemons := turtleDemons copyWith: aSelector.
