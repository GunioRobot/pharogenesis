addPackage: aString
	"Add the package aString to the receiver."

	^ self add: (GoferPackageReference name: aString repository: self repository)