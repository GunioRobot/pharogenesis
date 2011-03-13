addWorldDemon: aSelector
	"Add the given selector to the list of selectors sent to the world on every step."

	worldDemons := worldDemons copyWith: aSelector.
