extractStaticDirective
	"Scan the top-level statements for an inlining directive of the form:

		self static: <boolean>

	 and remove the directive from the method body. Return the argument of the directive or true if there is no static directive."

	| result newStatements |
	result _ true.
	newStatements _ OrderedCollection new: parseTree statements size.
	parseTree statements do: [ :stmt |
		(stmt isSend and: [stmt selector = #static:]) ifTrue: [
			result _ stmt args first name ~= 'false'.
		] ifFalse: [
			newStatements add: stmt.
		].
	].
	parseTree setStatements: newStatements asArray.
	^ result