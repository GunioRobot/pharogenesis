removeMaintainer: anAccount
	"Remove anAccount as a maintainer."

	maintainers ifNil: [^self].
	maintainers remove: anAccount.
	anAccount removeCoObject: self