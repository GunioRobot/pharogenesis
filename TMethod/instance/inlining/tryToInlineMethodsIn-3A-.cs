tryToInlineMethodsIn: aCodeGen
	"Expand any (complete) inline methods called by this method. Set the complete bit when all inlining has been done. Return true if something was inlined."

	| stmtLists didSomething newStatements inlinedStmts sendsToInline |
	didSomething _ false.

	sendsToInline _ Dictionary new: 100.
	parseTree nodesDo: [ :n |
		(self inlineableFunctionCall: n in: aCodeGen) ifTrue: [
			sendsToInline at: n put: (self inlineFunctionCall: n in: aCodeGen).
		].
	].
	sendsToInline isEmpty ifFalse: [
		didSomething _ true.
		parseTree _ parseTree replaceNodesIn: sendsToInline.
	].

	didSomething ifTrue: [
		possibleSideEffectsCache _ nil.
		^didSomething
	].

	stmtLists _ self statementsListsForInlining.
	stmtLists do: [ :stmtList | 
		newStatements _ OrderedCollection new: 100.
		stmtList statements do: [ :stmt |
			inlinedStmts _ self inlineCodeOrNilForStatement: stmt in: aCodeGen.
			(inlinedStmts = nil) ifTrue: [
				newStatements addLast: stmt.
			] ifFalse: [
				didSomething _ true.
				newStatements addAllLast: inlinedStmts.
			].
		].
		stmtList setStatements: newStatements asArray.
	].

	didSomething ifTrue: [
		possibleSideEffectsCache _ nil.
		^didSomething
	].

	complete ifFalse: [
		self checkForCompleteness: stmtLists in: aCodeGen.
		complete ifTrue: [ didSomething _ true ].  "marking a method complete is progress"
	].
	^didSomething