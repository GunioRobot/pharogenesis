methodsWithCallForClasses: classes enabled: enabledFlag 
	| result |
	result := OrderedCollection new.
	classes
		do: [:class | result
				addAll: (self methodsWithCallForClass: class enabled: enabledFlag)].
	^ result