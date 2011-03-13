authorizer: anAuthorizer
	"Smash all old name/password pairs with this new set.  Overwrites the file on the disk"

	| fName refStream |
	authorizer _ anAuthorizer.
	fName _ ServerAction serverDirectory, name, (ServerAction pathSeparator), 
				'authorizer'.
	refStream _ SmartRefStream fileNamed: fName.
	refStream nextPut: authorizer; close.
