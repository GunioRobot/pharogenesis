recordDeclarations
	"Record C type declarations of the forms

		self returnTypeC: 'float'.
		self var: #foo declareC: 'float foo'

	 and remove the declarations from the method body."

	| newStatements isDeclaration |
	newStatements _ OrderedCollection new: parseTree statements size.
	parseTree statements do: [ :stmt |
		isDeclaration _ false.
		stmt isSend ifTrue: [
			stmt selector = #var:declareC: ifTrue: [
				isDeclaration _ true.
				declarations at: stmt args first value asString put: stmt args last value.
			].
			stmt selector = #returnTypeC: ifTrue: [
				isDeclaration _ true.
				returnType _ stmt args last value.
			].
		].
		isDeclaration ifFalse: [
			newStatements add: stmt.
		].
	].
	parseTree setStatements: newStatements asArray.