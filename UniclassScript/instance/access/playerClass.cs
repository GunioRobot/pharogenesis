playerClass
	"Answer the playerClass associated with the receiver"

	^ playerClass ifNil:
		[playerClass _ currentScriptEditor playerScripted ifNotNil: [currentScriptEditor playerScripted class]]