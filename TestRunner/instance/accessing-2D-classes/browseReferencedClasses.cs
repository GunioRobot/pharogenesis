browseReferencedClasses
	| references |
	references := classesSelected gather: [ :class |
		class methodDict values , class class methodDict values gather: [ :method |
			method literals
				select: [ :each | each isVariableBinding and: [ each value isBehavior ] ]
				thenCollect: [ :each | each value ] ] ].
	(self browserEnvironment new forClasses: references asSet)
		label: 'Referenced Classes';
		openEditor.