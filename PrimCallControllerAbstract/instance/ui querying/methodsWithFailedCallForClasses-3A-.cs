methodsWithFailedCallForClasses: classes
	| result |
	result := OrderedCollection new.
	classes
		do: [:class | result
				addAll: (self methodsWithFailedCallForClass: class)].
	^ result