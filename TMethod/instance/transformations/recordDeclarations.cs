recordDeclarations
	"Record C type declarations of the forms

		self returnTypeC: 'float'.
		self var: #foo declareC: 'float foo'
		self var: #foo type:'float'.

	 and remove the declarations from the method body."

	| newStatements isDeclaration varName varType |
	newStatements _ OrderedCollection new: parseTree statements size.
	parseTree statements do: [ :stmt |
		isDeclaration _ false.
		stmt isSend ifTrue: [
			stmt selector = #var:declareC: ifTrue: [
				isDeclaration _ true.
				declarations at: stmt args first value asString put: stmt args last value.
			].
			stmt selector = #var:type: ifTrue: [
				isDeclaration _ true.
				varName _ stmt args first value asString.
				varType _ stmt args last value.
				declarations at: varName put: (varType, ' ', varName).
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