recognize: dispatcherArray as: resultCollectionClass 
	"Collect all items in a new resultCollectionClass"

	| resultCollection |
	resultCollection := resultCollectionClass new.
	self recognize: dispatcherArray do: [:item | resultCollection add: item].
	^resultCollection