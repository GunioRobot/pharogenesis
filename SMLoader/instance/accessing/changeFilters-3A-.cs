changeFilters: anObject 
	"Update my selection."

	| oldItem index |
	oldItem := self selectedPackageOrRelease.
	filters := anObject.
	self packagesListIndex: ((index := self packageList indexOf: oldItem) 
				ifNil: [0]
				ifNotNil: [index]).
	self noteChanged