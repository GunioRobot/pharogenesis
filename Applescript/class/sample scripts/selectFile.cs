selectFile
	"Harness Apple's select file dialog for Squeak"

	^self doIt: '(choose file with prompt "Hi guys!" of type "TEXT") as string'
