keysSorted

	| keys |
	keys _ SortedCollection new.
	self do: [:item | keys add: (keyBlock value: item)].
	^ keys