addMaintainer: anAccount
	"Add anAccount as a maintainer."

	maintainers ifNil: [maintainers _ OrderedCollection new].
	maintainers add: anAccount.
	anAccount addCoObject: self