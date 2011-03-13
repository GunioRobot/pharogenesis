quit
	Preferences readOnlyMode
		ifTrue: [""(self confirm: 'REALLY quit Squeak?' translated)
				ifTrue: [SmalltalkImage current snapshot: false andQuit: true]]
		ifFalse: [| saveBeforeQuitting | 
			saveBeforeQuitting := self
						confirm: 'Save changes before quitting?' translated
						orCancel: [^ self].
			SmalltalkImage current snapshot: saveBeforeQuitting andQuit: true]