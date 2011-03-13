test1: aProject
"EToyProjectQueryMorph test1: nil"

	| criteria clean |

	(self basicNew)
		project: aProject
		actionBlock: [ :x | 
			criteria := OrderedCollection new.
			x keysAndValuesDo: [ :k :v |
				(clean := v withBlanksTrimmed) isEmpty ifFalse: [
					criteria add: k,': *',clean,'*'
				].
			].
			SuperSwikiServer testOnlySuperSwiki queryProjectsAndShow: criteria
		];

		initialize;
		openCenteredInWorld