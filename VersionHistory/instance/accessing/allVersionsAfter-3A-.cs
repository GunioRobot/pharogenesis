allVersionsAfter: aVersion
	"Answer all the versions based on aVersion."

	| answer |
	answer := Set new.
	versions do: [ :ea |
		((ea inSameBranchAs: aVersion) and: 
			[ea > aVersion]) ifTrue: [answer add: ea]].
	^answer