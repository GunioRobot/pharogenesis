releaseMenu
	"self releaseMenu"
	|symbol|
	symbol := UIManager default
		chooseFrom: #('1- Prepare new update'
						'2- Done applying changes'
						'3- Verify new update (other image, same folder)'
						'4- Publish changes')
		values: #(prepareNewUpdate doneApplyingChanges verifyNewUpdate publishChanges).
	symbol ifNotNil: [ScriptLoader new perform: symbol]