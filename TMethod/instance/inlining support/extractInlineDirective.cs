extractInlineDirective
	"Scan the top-level statements for an inlining directive of the form:

		self inline: <boolean>

	 and remove the directive from the method body. Return the argument of the directive or #dontCare if there is no inlining directive."

	| result newStatements |
	result _ #dontCare.
	newStatements _ OrderedCollection new: parseTree statements size.
	parseTree statements do: [ :stmt |
		(stmt isSend and: [stmt selector = #inline:]) ifTrue: [
			result _ stmt args first name = 'true'.
		] ifFalse: [
			newStatements add: stmt.
		].
	].
	parseTree setStatements: newStatements asArray.
	^ result