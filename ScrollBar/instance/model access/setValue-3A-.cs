setValue: newValue
	"Using roundTo: instead of truncateTo: ensures that scrollUp will scroll the same distance as scrollDown."
	^ super setValue: (newValue roundTo: scrollDelta)