firstVersion
	"Answer the first version in the entire version history"

	^versions inject: versions anyOne into: [ :x :ea |
		(x inSameBranchAs: ea)
			ifTrue: [(x < ea) ifTrue: [x] ifFalse: [ea]]
			ifFalse: [ea]]