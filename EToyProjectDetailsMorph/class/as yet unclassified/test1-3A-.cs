test1: aProject
"EToyProjectDetailsMorph test1: Project current"

	(self basicNew)
		project: aProject
		actionBlock: [ :x | 
			aProject world setProperty: #ProjectDetails toValue: x.
			x at: 'projectname' ifPresent: [ :newName | 
				newName = aProject name ifFalse: [aProject changeSet name: newName].
			]
		];

		initialize;
		openCenteredInWorld