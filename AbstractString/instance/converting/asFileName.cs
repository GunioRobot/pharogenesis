asFileName
	"Answer a String made up from the receiver that is an acceptable file 
	name."

	| string checkedString |
	string _ (FilePath pathName: self) asVmPathName.
	checkedString _ FileDirectory checkName: string fixErrors: true.
	^ (FilePath pathName: checkedString isEncoded: true) asSqueakPathName.
