openSyntaxView
	"Open a syntax view on the current method"

	| class selector |

	(selector _ self selectedMessageName) ifNotNil: [
		class _ self selectedClassOrMetaClass.
		SyntaxMorph testClass: class andMethod: selector.
	]