onServer: aProjectServer
	"EToyProjectQueryMorph onServer: SuperSwikiServer testOnlySuperSwiki"

	| criteria clean |

	(self basicNew)
		project: nil
		actionBlock: [ :x | 
			criteria _ OrderedCollection new.
			x keysAndValuesDo: [ :k :v |
				(clean _ v withBlanksTrimmed) isEmpty
					ifFalse: [criteria add: k,': *',clean,'*']].
			aProjectServer queryProjectsAndShow: criteria];

		initialize;
		openCenteredInWorld