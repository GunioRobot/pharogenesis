acceptOnFocusChange
	"Answer whether the editor accepts its contents when it loses the keyboard focus."

	^self valueOfProperty: #acceptOnFocusChange ifAbsent: [false]