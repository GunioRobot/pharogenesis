shiftedYellowButtonActivity
	"Invoke the model's menu."

	| menu sel |
	menu _ view getMenuShifted.
	menu == nil
		ifTrue: [sensor waitNoButton]
		ifFalse: [(sel _ menu startUp) ifNil: [^ self].
			model doMenuItem: sel paneID: view getTextSelector from: self].
