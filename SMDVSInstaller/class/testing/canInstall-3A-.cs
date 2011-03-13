canInstall: aPackage
	"Can I install this? First we check if class StreamPackageLoader
	is available, otherwise DVS isn't installed.
	Then we check if the package is categorized with package
	format DVS - currently we have hardcoded the id of that category."

	| fileName |
	Smalltalk at: #StreamPackageLoader ifPresentAndInMemory: [ :loader |
		fileName := aPackage downloadFileName.
		fileName ifNil: [^false].
		fileName := fileName asLowercase.
		^((fileName endsWith: '.st') or: [fileName endsWith: '.st.gz'])
			and: [aPackage categories includes: "The DVS format category"
					(SMSqueakMap default
						categoryWithId: 'b02f51f4-25b4-4117-9b65-f346215a8e41')]].
	^false