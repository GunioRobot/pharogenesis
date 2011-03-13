addMaintainer: anAccount
	"Add anAccount as a maintainer."

	maintainers ifNil: [maintainers := OrderedCollection new].
	maintainers add: anAccount.
	anAccount addCoObject: self