countInstall
	"Increase the install counter."

	installCounter ifNil: [installCounter _ 0].
	^installCounter _ installCounter + 1
