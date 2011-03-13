testMajorMinorVersion
	"
	SystemVersionTest run: #testMajorMinorVersion
	"
	self assert: (SystemVersion new version: 'Squeak3.7alpha') majorMinorVersion = 'Squeak3.7'.
	self assert: (SystemVersion new version: 'Squeak3.7') majorMinorVersion = 'Squeak3.7'.
	self assert: (SystemVersion new version: 'Squeak3') majorMinorVersion = 'Squeak3'.
	self assert: (SystemVersion new version: '') majorMinorVersion = ''.
