secureUserDirectory
	"SecurityManager default secureUserDirectory"
	"Primitive. Return the directory where we can securely store data that is not accessible in restricted mode."
	<primitive: 'primitiveGetSecureUserDirectory' module: 'SecurityPlugin'>
	^FileDirectory default pathName