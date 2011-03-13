asFileName
	"Answer a String made up from the receiver that is an acceptable file 
	name."

	| string checkedString |
	string := FileDirectory checkName: self fixErrors: true.
	checkedString := (FilePath pathName: string) asVmPathName.
	^ (FilePath pathName: checkedString isEncoded: true) asSqueakPathName.
