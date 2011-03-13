initializeEventSensorConstants
	"EventSensor initialize"
	Smalltalk declare: #EventSensorConstants from: Undeclared.
	EventSensorConstants == nil ifTrue:[EventSensorConstants _ Dictionary new].
	#(
		(RedButtonBit 4)
		(BlueButtonBit 2)
		(YellowButtonBit 1)

		(ShiftKeyBit 1)
		(CtrlKeyBit 2)
		(OptionKeyBit 4)
		(CommandKeyBit 8)

		"Types of events"
		(EventTypeNone 0)
		(EventTypeMouse 1)
		(EventTypeKeyboard 2)
		(EventTypeDragDropFiles 3)

		"Press codes for keyboard events"
		(EventKeyChar 0)
		(EventKeyDown 1)
		(EventKeyUp 2)

	) do:[:spec|
		EventSensorConstants declare: spec first from: Undeclared.
		EventSensorConstants at: spec first put: spec last.
	].