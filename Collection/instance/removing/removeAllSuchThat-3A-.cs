removeAllSuchThat: aBlock
	"Apply the condition to each element and remove it if the condition is true.  Use a copy to enumerate collections whose order changes when an element is removed (Set)."
	| copy newCollection |
	newCollection _ self species new.
	copy _ self copy.
	copy do: [:element |
		(aBlock value: element) ifTrue: [
			self remove: element.
			newCollection add: element]].
	^ newCollection