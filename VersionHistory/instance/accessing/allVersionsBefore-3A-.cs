allVersionsBefore: aVersion
	"Answer all versions that came before aVersion"

	| answer |
	answer := Set new.
	versions do: [ :ea |
		((ea inSameBranchAs: aVersion) and: 
			[ea < aVersion]) ifTrue: [answer add: ea]].
	^answer