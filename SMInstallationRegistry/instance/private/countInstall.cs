countInstall
	"Increase the install counter."

	installCounter ifNil: [installCounter := 0].
	^installCounter := installCounter + 1
