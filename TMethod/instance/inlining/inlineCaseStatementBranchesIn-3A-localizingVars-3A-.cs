inlineCaseStatementBranchesIn: aCodeGen localizingVars: varsList

	| stmt sel meth newStatements maxTemp usedVars exitLabel v |
	maxTemp _ 0.
	parseTree nodesDo: [ :n |
		n isCaseStmt ifTrue: [
			n cases do: [ :stmtNode |
				stmt _ stmtNode statements first.
				stmt isSend ifTrue: [
					sel _ stmt selector.
					meth _ aCodeGen methodNamed: sel.
					((meth ~= nil) and:
					 [meth hasNoCCode and:
					 [meth args size = 0]]) ifTrue: [
						meth _ meth copy.
						maxTemp _ maxTemp max: (meth renameVarsForCaseStmt).

						meth hasReturn ifTrue: [
							exitLabel _ self unusedLabelForInliningInto: self.
							meth exitVar: nil label: exitLabel.
							labels add: exitLabel.
						] ifFalse: [ exitLabel _ nil ].

						meth renameLabelsForInliningInto: self.
						meth labels do: [ :label | labels add: label ].
						newStatements _ stmtNode statements asOrderedCollection.
						newStatements removeFirst.

						exitLabel ~= nil ifTrue: [
							newStatements addFirst:
								(TLabeledCommentNode new
									setLabel: exitLabel comment: 'end case').
						].

						newStatements addAllFirst: meth statements.
						newStatements addFirst:
							(TLabeledCommentNode new setComment: meth selector).
						stmtNode setStatements: newStatements.
					].
				].
			].
		].
	].
	usedVars _ (locals, args) asSet.
	1 to: maxTemp do: [ :i |
		v _ ('t', i printString).
		(usedVars includes: v) ifTrue: [ self error: 'temp variable name conflicts with an existing local or arg' ].
		locals addLast: v.
	].

	"make local versions of the given globals"
	varsList do: [ :var |
		(usedVars includes: var) ifFalse: [ locals addFirst: var asString ].
	].
