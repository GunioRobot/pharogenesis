extractSharedCase
	"Scan the top-level statements for an shared case directive of the form:

		self sharedCodeNamed: <sharedLabel> inCase: <sharedCase>.

	and remove the directive from the method body."

	| newStatements |
	newStatements _ OrderedCollection new: parseTree statements size.
	parseTree statements do: [ :stmt |
		(stmt isSend and: [stmt selector = #sharedCodeNamed:inCase:]) ifTrue: [
			sharedLabel _ stmt args first value.
			sharedCase _ stmt args last value
		] ifFalse: [
			newStatements add: stmt.
		].
	].
	parseTree setStatements: newStatements asArray.
	sharedCase ifNotNil:[
		args isEmpty ifFalse:[self error: 'Cannot share code sections in methods with arguments'].
	].