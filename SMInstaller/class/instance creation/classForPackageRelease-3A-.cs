classForPackageRelease: aPackageRelease
	"Decide which subclass to instantiate. 
	We detect and return the first subclass
	that wants to handle the release going
	recursively leaf first so that subclasses gets
	first chance if several classes compete over
	the same packages, like for example SMDVSInstaller
	that also uses the .st file extension."

	self subclasses do: [:ea |
		(ea classForPackageRelease: aPackageRelease)
			ifNotNilDo: [:class | ^ class]].
	^(self canInstall: aPackageRelease)
		ifTrue: [self]