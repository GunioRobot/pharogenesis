selectedPackageOrRelease
	"Return selected package or package release."

	^(self selectedItemWrapper isNil) ifFalse: [self selectedItemWrapper withoutListWrapper]