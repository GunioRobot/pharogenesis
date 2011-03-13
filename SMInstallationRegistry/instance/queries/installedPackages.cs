installedPackages
	"Answer all packages that we know are installed.
	Lazily initialize. The Dictionary contains the installed packages
	using their UUIDs as keys and the version string as the value."

	| result p |
	result := OrderedCollection new.
	installedPackages ifNil: [^#()]
		ifNotNil: [installedPackages keys
					do: [:k |
						p := map object: k.
						p ifNotNil: [result add: p]]].
	^result