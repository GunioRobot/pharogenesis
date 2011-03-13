collectConflictsIn: collectionOfReleases
	"Collect all conflicts where there are either
		- multiple releases of the same package and/or
		- another release of the same package already installed
	Return the conflicts as an IdentityDictionary with
	the package as key and the value being a Set of releases."

	| conflicts set |
	conflicts := IdentityDictionary new.
	collectionOfReleases do: [:r |
		set := conflicts at: r package ifAbsent: [
				conflicts at: r package put: OrderedCollection new].
		set add: r].
	"Add the installed releases too"
	conflicts keysAndValuesDo: [:key :value |
		key isInstalled ifTrue: [value add: key installedRelease]].
	"Prune release sets with only one member"
	^conflicts select: [:releaseSet | releaseSet size > 1]