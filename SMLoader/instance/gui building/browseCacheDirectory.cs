browseCacheDirectory
	"Open a FileList2 on the directory for the package or release."

	| item dir win |
	item := self selectedPackageOrRelease.
	item ifNil: [^nil].
	dir := item isPackage
				ifTrue: [squeakMap cache directoryForPackage: item]
				ifFalse: [squeakMap cache directoryForPackageRelease: item].
	win := FileList2 morphicViewOnDirectory: dir. " withLabel: item name, ' cache directory'."
	win openInWorld
