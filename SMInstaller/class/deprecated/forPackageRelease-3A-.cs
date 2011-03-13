forPackageRelease: aPackageRelease
	"Instantiate the first class suitable to install the package release.
	If no installer class is found we raise an Error."

	| class |
	aPackageRelease ifNil: [self error: 'No package release specified to find installer for.'].
	class := self classForPackageRelease: aPackageRelease.
	^class
		ifNil: [self error: 'No installer found for package ', aPackageRelease name, '.']
		ifNotNil: [class new packageRelease: aPackageRelease]