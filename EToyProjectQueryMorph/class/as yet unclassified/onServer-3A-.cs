onServer: aProjectServer
	"EToyProjectQueryMorph onServer: SuperSwikiServer testOnlySuperSwiki"

	| criteria clean |

	(self basicNew)
		project: nil
		actionBlock: [ :x | 
			criteria := OrderedCollection new.
			x keysAndValuesDo: [ :k :v |
				(clean := v withBlanksTrimmed) isEmpty
					ifFalse: [criteria add: k,': *',clean,'*']].
			aProjectServer queryProjectsAndShow: criteria];

		initialize;
		becomeModal;
		openCenteredInWorld