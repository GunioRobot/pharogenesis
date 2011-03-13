keysSorted
 
 	| keys |
 	keys := SortedCollection new.
 	self do: [:item | keys add: (keyBlock value: item)].
 	^ keys