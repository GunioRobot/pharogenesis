fixSharedCodeBlocksForCase: caseIndex in: caseParseTree
	"Process 'sharedCode' directives in the given parse tree. The sharedCode directive allows code replicated in different arms of a case statement to be shared. The replicated code must be the final code of the case so that it ends with a break out of the case statement. The replicated code will be generated in exactly one arm of the case statement; other instances of the shared code will be replaced by branches to that single instance of the code."

	"NOTE: I have made this work for the nested case (ie several shared entry points in the same case, but it does not really work for methods with arguments.  A mechanism coud be added that would add a preamble of the form,
	innerSharedTemp = outerTemp;
when they differed.  There should at least be a test here."

	| copying oldStmts newStmts stmt codeBlockName |
	caseParseTree  nodesDo: [ :node |
		node isStmtList ifTrue: [
			copying _ true.
			oldStmts _ node statements asArray.
			newStmts _ nil.  "becomes an OrderedCollection if sharedCode block is found"
			1 to: oldStmts size do: [ :i |
				copying ifTrue: [
					stmt _ oldStmts at: i.
					(stmt isSend and: [stmt selector = #sharedCodeNamed:inCase:]) ifTrue: [
						newStmts == nil 
							ifTrue: [newStmts _ (oldStmts copyFrom: 1 to: i - 1) asOrderedCollection]
							ifFalse: [newStmts removeLast "preserve any prior shared entry points - di"].
						codeBlockName _ stmt args first value.
						(stmt args last value = caseIndex) ifTrue: [
							newStmts add: 
								(TLabeledCommentNode new setLabel: codeBlockName comment: '').
						] ifFalse: [
							newStmts add: (TGoToNode new setLabel: codeBlockName).
							copying _ false.  "don't copy remaining statements"
						].
					] ifFalse: [
						newStmts = nil ifFalse: [newStmts add: stmt].
					].
				] ifFalse: [	"ikp: this permits explicit returns before 'goto aSharedCodeLabel'"
					stmt _ oldStmts at: i.
					(stmt isLabel and: [stmt label ~= nil]) ifTrue: [newStmts add: stmt].
				].
			].
			newStmts = nil ifFalse: [node setStatements: newStmts].
		].
	].