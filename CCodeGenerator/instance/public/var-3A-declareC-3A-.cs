var: varName declareC: declarationString
	"Record the given C declaration for a global variable."

	variableDeclarations at: varName asString put: declarationString.