saveDoc: aMorph
	"Broadcast this documentation to the Squeak community.  Associate it with the method it documents.  Send to a drop box, where it can be inspected before being posted on External servers."

	| classAndMethod fName remoteFile |
	classAndMethod _ aMorph valueOfProperty: #classAndMethod.
	classAndMethod ifNil: [
		^ self error: 'need to know the class and method'].	"later let user set it"
	fName _ (self docNamesAt: classAndMethod) first.
	DropBox user asLowercase = 'anonymous' ifTrue: [
		fName _ fName, 1000 atRandom printString].	"trusted users store directly"
	DropBox password.	"In case user has to type it.  Avoid timeout from server"
	Cursor wait showWhile: [
		remoteFile _ DropBox fileNamed: fName.
		remoteFile fileOutClass: nil andObject: aMorph.
		"remoteFile close"].
