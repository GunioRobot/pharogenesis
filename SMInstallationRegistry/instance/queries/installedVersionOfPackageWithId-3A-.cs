installedVersionOfPackageWithId: anId
	"If the package is installed, return the automatic version or version String.
	Otherwise return nil. This can be used without the map loaded."

	| autoVersionOrOld |
	installedPackages ifNil: [^nil].
	autoVersionOrOld := (installedPackages at: anId ifAbsent: [^nil]) last first.
	(autoVersionOrOld isKindOf: Association)
		ifTrue: [
			^autoVersionOrOld value]
		ifFalse: [
			^autoVersionOrOld]