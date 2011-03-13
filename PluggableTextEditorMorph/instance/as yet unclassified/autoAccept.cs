autoAccept
	"Answer whether the editor accepts its contents on each change."

	^self valueOfProperty: #autoAccept ifAbsent: [false]