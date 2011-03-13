yellowButtonActivity
	"Invoke the model's menu."
	| menu sel |
	menu _ view getMenu.
	menu == nil
		ifTrue: [sensor waitNoButton]
		ifFalse: [(sel _ menu startUp) ifNil: [^ self].
			self controlTerminate.
			model perform: sel orSendTo: self.
			self controlInitialize].
