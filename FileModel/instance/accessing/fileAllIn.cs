fileAllIn
	"FileIn all of the contents from the external file"
	| f |
	f _ FileStream oldFileNamed: self fullName.
	f fileIn